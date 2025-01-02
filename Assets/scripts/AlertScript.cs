using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class AlertScript : MonoBehaviour
{
    public Text alertText;
    private List<Alert> alerts = new List<Alert>();
    public float alertInterval = 10;
    private Coroutine alertCoroutine;
    private Alert nextAlertInSequence;
    private playerMovment player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<playerMovment>();
        Alert newALert = new Alert("bye bye", () => player.changeSpeed(-5));
        alerts.Add(new Alert("משטרה בעיקבותיך אתה חייב למהר!!!", () => player.changeSpeed(5), newALert));

      
        alerts.Add(new Alert("משטרה בעיקבותיך אתה חייב למהר!!!", () => player.changeSpeed(5), newALert));
        alerts.Add(new Alert("משטרה בעיקבותיך אתה חייב למהר!!!", () => player.changeSpeed(5), newALert));
        alerts.Add(new Alert("משטרה בעיקבותיך אתה חייב למהר!!!", () => player.changeSpeed(5), newALert));
      
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

    private void limitArea()
    {
        Debug.Log("area Limiting");
        // limiting area code
    }

    private void changeSpeed(float newSpeed)
    {
        Debug.Log($"Speed changed to {newSpeed}!");
        // implement speed
    }

    private void doNothing()
    {
        Debug.Log("Do nothing");
    }
}