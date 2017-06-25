using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour {

    public Toggle otherButton;
	public void TurnOn(bool toggle)
    {
        if (toggle)
        {
            GetComponent<Toggle>().interactable = false;
            otherButton.interactable = true;
        }
    }
}
