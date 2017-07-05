using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I want this to be a permanent change
[ExecuteInEditMode]
// sets up the color and visibility of the clickable countries
public class MaterialChange : MonoBehaviour
{
    private Renderer[] rends;
    public Color preset;
    private void Awake()
    {
        Transform[] kids = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform trans in kids)
        {
            GameObject gO = trans.gameObject;
            rends = gO.GetComponentsInChildren<Renderer>();

            // loop through all the mesh renderers and change their materials
            for (int i = 0; i < rends.Length; i++)
            {
                rends[i].sharedMaterial.shader = Shader.Find("Unlit/Color");
                rends[i].sharedMaterial.color = preset; // orange-ish
                rends[i].enabled = false; // not visible at start of program
            }

        }
    }
}