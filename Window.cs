using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour {

    public void SetVisibility(string button)
    {
        if (button.CompareTo("open") == 0)
            gameObject.SetActive(true);
        else if (button.CompareTo("close") == 0)
            gameObject.SetActive(false);
    }
}
