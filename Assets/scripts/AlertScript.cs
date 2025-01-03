using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class AlertScript : MonoBehaviour
{
    public playerMovment playerMovment;
    public Text alertText;
    private List<Alert> alerts = new List<Alert>();
    public float alertInterval = 15;
    private Coroutine alertCoroutine;
    private Alert nextAlertInSequence;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovment = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovment>();

        Alert secondAlert = new Alert("Nevermind he's white...", () => changeSpeed(6));
        alerts.Add(new Alert("You are under arrest for stealing that drill. No! Don't run! Why are you going so fast?", () => changeSpeed(12), secondAlert));
        alerts.Add(new Alert("HAHAHA! Your drill is broken now! Digging is a lot slower!", () => changeSpeed(5)));
        alerts.Add(new Alert("You look ugly. Yeah! Be insulted!", () => changeSpeed(2)));

        alertCoroutine = StartCoroutine(DisplayRandomAlerts());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DisplayRandomAlerts()
    {
        while (true)
        {
            // Wait for the interval
            yield return new WaitForSeconds(alertInterval);

            // If an alert is active, hide it
            if (alertText.gameObject.activeSelf)
            {
                alertText.gameObject.SetActive(false);
            }

            Alert selectedAlert;

            // Check if there's a sequential alert
            if (nextAlertInSequence != null)
            {
                selectedAlert = nextAlertInSequence;
                nextAlertInSequence = null; // Clear the sequence pointer after using it
            }
            else
            {
                // Pick a random alert
                int randomIndex = Random.Range(0, alerts.Count);
                selectedAlert = alerts[randomIndex];
            }

            // Display the message
            alertText.text = selectedAlert.alertName;
            alertText.gameObject.SetActive(true);

            // Trigger the consequence
            selectedAlert.consequence?.Invoke();

            // Set the next alert in the sequence if applicable
            if (selectedAlert.nextAlert != null)
            {
                nextAlertInSequence = selectedAlert.nextAlert;
            }
        }
    }

    public void StopAlerts()
    {
        if (alertCoroutine != null)
            StopCoroutine(alertCoroutine);
    }

    private void changeSpeed(float newSpeed)
    {
        Debug.Log($"Speed changed to {newSpeed}!");
        playerMovment.setSpeed(newSpeed);
    }
}