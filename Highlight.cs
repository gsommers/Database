using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highlight : MonoBehaviour {

    private Button simpleButton; // makes the empire map clickable

    void Start()
    {
        simpleButton = GameObject.Find("Simple").GetComponent<Button>();
    }
    // highlights a clickable country when mouse is over it
    void OnMouseEnter()
    {
        if (!simpleButton.enabled) // we're on the empire map
        {
            Switch(true);
        }
    }

    // hides a clickable country when mouse is no longer over it
    private void OnMouseExit()
    {
        Switch(false);
    }

    void Switch(bool toggle)
    {
        // game object for the entire region/country
        GameObject gO = transform.parent.gameObject;

        // the game object's children all have mesh renderers attached
        Renderer[] rends = gO.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < rends.Length; i++)
        {
            rends[i].enabled = toggle;
        }
    }

}
