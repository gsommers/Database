using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpWindow : MonoBehaviour {

    public GameObject helpWindow;
    private void Start()
    {
        helpWindow.SetActive(false);
    }

    public void SetVisibility(string button)
    {
        if (button.CompareTo("help") == 0)
            helpWindow.SetActive(true);
        else if (button.CompareTo("x") == 0)
            helpWindow.SetActive(false);
    }
}
