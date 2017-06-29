using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomClick : MonoBehaviour {

    private List<Dropdown.OptionData> options;
    private Dropdown countries;

    private GameObject zoomView;
    private Vector3 position;
    private Image country;

    private GameObject simple;
    private RectTransform simpleMap;
    private Button simpleButton;
    private Animator simpleSize;

    public string countryName;

    private void Start()
    {
        zoomView = GameObject.FindWithTag("Zoom");
        simple = GameObject.FindWithTag("Map");
        simpleMap = simple.GetComponent<RectTransform>();
        country = GameObject.FindWithTag("Country").GetComponent<Image>();
        position = new Vector3(-330, 200, 0);
        simpleButton = simple.GetComponent<Button>();
        simpleSize = simple.GetComponent<Animator>();
        countries = GameObject.FindWithTag("Dropdown").GetComponent<Dropdown>();
        options = countries.options;
    }

    public void ChooseCountry()
    {
        simpleMap.localPosition = position;
        zoomView.GetComponent<Image>().color = Color.white;
        country.sprite = ((GameObject)Resources.Load(countryName)).GetComponent<Image>().sprite;
        country.SetNativeSize();
        SetSize();
        SetEnable(true);
    }

    // in case the picture is too small
    private void SetSize()
    {
        RectTransform rect = country.GetComponentInParent<RectTransform>();
        float width = rect.sizeDelta.x;
        float height = rect.sizeDelta.y;
        if (width < 1000) // I should be declaring these as constants...
            rect.sizeDelta = new Vector2(1000, height * 1000 / width);
        if (rect.sizeDelta.y < 750)
            rect.sizeDelta = new Vector2(rect.sizeDelta.x * 750 / rect.sizeDelta.y, 750);
    }

    public void SetCountry()
    {
        if (countries.value > 0)
        {
            countryName = options[countries.value].text;
            ChooseCountry();
        }
    }

    void OnMouseUpAsButton()
    {
        if (Input.mousePosition.y > 100 && !simpleButton.enabled && countries.GetComponentInChildren<ScrollRect>() == null)
        {
            ChooseCountry();
        }
    }

    private void SetEnable(bool toggle)
    {
        simpleButton.enabled = toggle;
        simpleSize.enabled = toggle;
    }

    public void Unzoom()
    {
        simpleMap.localScale = new Vector3(1, 1, 1);
        simpleMap.localPosition = new Vector3(1.5f, 50, 0);
        zoomView.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        SetEnable(false);
    }

}
