using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomClick : MonoBehaviour {

    private int count;
    public GameObject nextImage;
    public RectTransform simple;
    public float scale;
    public Vector3 position;
    private void Start()
    {
        count = 0;
        nextImage.SetActive(false);
    }

    void OnMouseUpAsButton()
    {
        count++;
        Debug.Log("You clicked Italy! Count: " + count);
        nextImage.SetActive(true);
        ScrollRect scroll = GetComponentInParent<ScrollRect>();
        scroll.content = nextImage.GetComponent<RectTransform>();
        simple.localScale = new Vector2(scale, scale);
        simple.localPosition = position;
    }

}
