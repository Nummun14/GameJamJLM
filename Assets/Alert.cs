using UnityEngine;
using System;

public class Alert
{
    public string alertName;
    public Action consequence;

    public Alert(string alertName, Action consequence)
    {
        this.alertName = alertName;
        this.consequence = consequence;
    }
}
