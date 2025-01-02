using UnityEngine;
using System;

public class Alert
{
    public string alertName;
    public Action consequence;
    public Alert nextAlert;

    public Alert(string alertName, Action consequence, Alert nextAlert = null)
    {
        this.alertName = alertName;
        this.consequence = consequence;
        this.nextAlert = nextAlert;
    }
}
