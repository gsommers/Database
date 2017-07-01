using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomClick : MonoBehaviour {

    private List<Dropdown.OptionData> options;
    private Dropdown countries;
    private Button submit;

    private GameObject zoomView;
    private Vector3 position;
    private Image country;

    private GameObject simple;
    private RectTransform simpleMap;
    private Button simpleButton;
    private Animator simpleSize;
    private string countryName;

    private void Start()
    {
        countries = GameObject.Find("Select").GetComponent<Dropdown>();
        options = countries.options;
        submit = GameObject.Find("Submit").GetComponent<Button>();

        zoomView = GameObject.Find("Zoom View");     
        position = new Vector3(-330, 200, 0);
        country = GameObject.Find("Country").GetComponent<Image>();

        simple = GameObject.Find("Simple");
        simpleButton = simple.GetComponent<Button>();
        simpleSize = simple.GetComponent<Animator>();
        simpleMap = simple.GetComponent<RectTransform>();
    }

    void OnMouseEnter()
    {
        if (!simpleButton.enabled)
        Switch(true);
    }

    private void OnMouseExit()
    {
        Switch(false);
    }

    void Switch(bool toggle)
    {
        GameObject gO = GameObject.Find(transform.parent.name);
        Renderer[] rends = gO.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < rends.Length; i++)
        {
            rends[i].enabled = toggle;
        }
    }
    public void ChooseCountry()
    {
        TextAsset readMe = LoadingExample.GetBundle().LoadAsset<TextAsset>("Test");
        print(readMe.text);
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

    public void SelectDropdown(int val)
    {
        if (val > 0)
            submit.interactable = true;
        else
            submit.interactable = false;

    }

    public void SetCountry()
    {
        countryName = options[countries.value].text;
        ChooseCountry();
    }

    public void Hit(string name)
    {
        countryName = name;
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
