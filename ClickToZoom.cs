using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToZoom : MonoBehaviour {

    private void Start()
    {
        transform.localPosition = new Vector3(-10, 0, 0);
        // centerPos = transform.position;
    }
    public void OnClick() // test
    {
        Debug.Log("reached");
        print("Is anything happening?");
        // RectTransform rT = GetComponent<RectTransform>();
        // Vector3 center = rT.rect.center;
        ////if the position is say 500 600,
        ////and I click at 600 700
        ////    then I want 600 700 to be moved to where 500 600 was,
        ////so I want to move it DOWN, right?
        ////    I want to change the position by the difference in position bw the transform and the mouse position
        ////    so I'll move the transform DOWN by 100 100
        //Vector3 diff = transform.position - Input.mousePosition;
        //transform.position = centerPos + diff;
        // Debug.Log(transform.position + " local " + transform.localPosition + " mouse " + Input.mousePosition + " center " + center);

        
    }

    // test
    //public void OnClick2()
    //{
    //    nextImage.SetActive(true);
    //    ScrollRect scroll = GetComponentInParent<ScrollRect>();
    //    scroll.content = nextImage.GetComponent<RectTransform>();
    //    thisImage.SetActive(false);
    //}

   

}
