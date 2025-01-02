using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class AlertScript : MonoBehaviour
{
    public Text alertText;
    private List<Alert> alerts = new List<Alert>();
    public float alertInterval = 10;
    private Coroutine alertCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        alerts.Add(new Alert("The neighors are complaining, don't dig in this area", limitArea));
        alerts.Add(new Alert("Do you have a permit for this?", changeSpeed, 4));
        alerts.Add(new Alert("You look ugly ", changeSpeed, 2));

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

            // Pick a random alert
            int randomIndex = Random.Range(0, alerts.Count);
            Alert randomAlert = alerts[randomIndex];

            // Display the message
            alertText.text = randomAlert.alertName;
            alertText.gameObject.SetActive(true);

            // Trigger the consequence
            randomAlert.consequence?.Invoke();
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
}