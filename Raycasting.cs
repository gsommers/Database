using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// detects when user clicks on a country
public class Raycasting : MonoBehaviour {

    private Ray ray; // imaginary line directed from mouse position
    public ZoomClick clickable;
    private void Update()
    {
        // I could just use onMouseDown, but this handles multiple collisions
        if (Input.GetMouseButton(0))
        {
            // detects if mouse clicks intersects with any country
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits) // should be only one
            {
                string name = hit.transform.parent.name;
                clickable.Hit(name); // method in ZoomClick script
            }
        }
   }
}
