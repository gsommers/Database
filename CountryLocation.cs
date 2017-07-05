using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountryLocation : MonoBehaviour {

    // positions the zoomed-in picture near the center of the screen
    private void Start()
    {
        transform.localPosition = new Vector3(-10, 0, 0);
    }
   

}
