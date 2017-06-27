using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomClick : MonoBehaviour {

    private GameObject zoomView;
    private GameObject simple;
    private RectTransform simpleMap;
    private Vector3 position;
    private Image country;
    public string countryName;

    private void Start()
    {
        zoomView = GameObject.FindWithTag("Zoom");
        simple = GameObject.FindWithTag("Map");
        simpleMap = simple.GetComponent<RectTransform>();
        country = GameObject.FindWithTag("Country").GetComponent<Image>();
        position = new Vector3(-330, 200, 0);
    }

    void OnMouseUpAsButton()
    {
        simpleMap.localPosition = position;
        simple.GetComponent<Button>().interactable = true;
        simpleMap.localScale = new Vector2(0.25f, 0.25f);
        zoomView.GetComponent<Image>().color = Color.white;
        country.sprite = ((GameObject)Resources.Load(countryName)).GetComponent<Image>().sprite;
    }

    public void Unzoom()
    {
        Debug.Log("Button");
        simpleMap.localScale = new Vector3(1, 1, 1);
        simpleMap.localPosition = new Vector3(1.5f, 50, 0);
        simple.GetComponent<Button>().interactable = false;
        zoomView.GetComponent<Image>().color = new Color(255, 255, 255, 0);

    }

}
