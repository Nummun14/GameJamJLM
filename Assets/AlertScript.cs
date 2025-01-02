using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class AlertScript : MonoBehaviour
{
    public Text alertText;
    private List<Alert> alerts = new List<Alert>();
    public float alertInterval = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        alerts.Add(new Alert("The neighors are complaining, don't dig in this area", limitArea));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void limitArea()
    {
        Debug.Log("area Limiting");
        // limiting area code
    }
}