using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    private Renderer[] rends;
    public Color preset;
    private void Start()
    {
        Transform[] kids = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform trans in kids)
        {
            GameObject gO = GameObject.Find(trans.name);
            rends = gO.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < rends.Length; i++)
            {
                rends[i].material.shader = Shader.Find("Unlit/Color");
                rends[i].material.color = preset;
                rends[i].enabled = false;
            }

        }
    }
}