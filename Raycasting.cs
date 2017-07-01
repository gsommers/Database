using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Raycasting : MonoBehaviour {

    private Ray ray;
    public ZoomClick clickable;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                string name = hit.transform.parent.name;
                clickable.Hit(name);
            }
        }
   }
}
