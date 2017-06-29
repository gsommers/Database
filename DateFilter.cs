using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Date: IComparable<Date>
{
    private int year;
    private bool era; // false for BC, true for AD

    public Date(string date, bool annoDom)
    {
        // check that it's a number
        year = Convert.ToInt32(date);
        era = annoDom;
    }

    public Date(string date)
    {
        // assuming it will be valid, since I'm typing it
        int space = date.IndexOf(" ");
        year = Convert.ToInt32(date.Substring(0, space));
        era = (date.Substring(space + 1) == "AD");
    }

    public void SetEra(bool toggle)
    {
        era = toggle;
    }

    public int CompareTo(Date other)
    {
        if (era == other.era) 
        {
            if (era) // both AD
            {
                Debug.Log("both AD");
                return year - other.year;         
            }
            else // both BC
                return other.year - year;
        }
        else if (era) // this date is AD
            return 1;
        else
            return -1;
    }
}

public class DateFilter : MonoBehaviour {

    private Date start, end;
    public Text startText, endText, errorText;
    private Color originalColor;
    public string earliest, latest;
    public Color errorColor;
    public Toggle startAD, endAD;

    private void Start()
    {
        originalColor = startText.color;
    }

    public void SetStart(string entry)
    {
        if (entry.Length > 0)
            start = new Date(entry, startAD.isOn);
        else
            start = null;
    }


    public void SetEnd(string entry)
    {
        if (entry.Length > 0)
            end = new Date(entry, endAD.isOn);
        else
            end = null;
    }

    public void ChangeEra(string type)
    {
        switch(type)
        {
            case "start":
                if (start != null) start.SetEra(startAD.isOn);
                break;
            case "end":
                if (end != null) end.SetEra(endAD.isOn);
                break;
        }
    }
    /* 
     * public void Test()
    {
        Debug.Log("Working!");
    }
    */

    private void SetErrorText(string message, string error)
    {
        errorText.text = message;
        switch (error)
        {
            case "start": errorText.alignment = TextAnchor.MiddleLeft;
                startText.color = errorColor;
                break;
            case "end": errorText.alignment = TextAnchor.MiddleRight;
                endText.color = errorColor;
                break;
            case "both": errorText.alignment = TextAnchor.MiddleCenter;
                endText.color = errorColor;
                startText.color = errorColor;
                break;
            case "neither": endText.color = originalColor;
                startText.color = originalColor;
                break;
        }
    }
    public void Submit()
    {
        // assuming all is correct
        SetErrorText("", "neither");

        if (start != null) // check start date for errors
        {
            CheckLimits(start, "start");
        }

        if (end != null) // check end date for errors
        {
            CheckLimits(end, "end");
        }

        if (start != null && end != null && start.CompareTo(end) > 0)
        {
            SetErrorText("Please select a start date that is earlier than the end date.", "both");
        }
    }

    private void CheckLimits(Date entry, string type)
    {
        if (entry.CompareTo(new Date(earliest)) < 0 || entry.CompareTo(new Date(latest)) > 0)
                SetErrorText(String.Format("Make sure that the {0} date is between {1} and {2}.", type, earliest, latest), type);
    }
}
