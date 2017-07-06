using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

// Makes the map "interactable"
public class ZoomClick : MonoBehaviour {

    // determines whether a user is clicking on a country, or a button above it
    private float minClick; // height of date panel
    private float minClickPlus; // height of date panel plus source panel
    private float clickPos;
    private float offset;

    private float ClickPos
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition).y + offset;
        }
    }

    // references related to the country/region dropdown
    private List<Dropdown.OptionData> options;
    private Dropdown countries;
    private Button submit;

    // instance variables related to the zoomed-in map of a single region
    private GameObject zoomView;
    private Vector3 position;
    private Image country;

    // references related to the panel that cites the source of the map
    private TextMeshProUGUI sourceText; // contains hyperlink
    private GameObject panel;

    // references related to the basic map of the entire empire
    private GameObject simple;
    private RectTransform simpleMap;
    private Button simpleButton;
    private Animator simpleSize;

    // used to load assets for each country/region
    private AssetBundle countryBundle;
    private string countryName;

    // assign instance variables 
    private void Awake()
    {
        // dropdown panel
        countries = GameObject.Find("Select").GetComponent<Dropdown>();
        options = countries.options;
        submit = GameObject.Find("Submit").GetComponent<Button>();

        // zoomed-in map
        zoomView = GameObject.Find("Zoom View");
        position = new Vector3(-330, 200, 0);
        country = GameObject.Find("Country").GetComponent<Image>();

        // citation pop-up
        panel = GameObject.Find("Source Panel");
        sourceText = GameObject.Find("Source").GetComponent<TextMeshProUGUI>();
       
        // zoomed-out map
        simple = GameObject.Find("Simple");
        simpleButton = simple.GetComponent<Button>();
        simpleSize = simple.GetComponent<Animator>();
        simpleMap = simple.GetComponent<RectTransform>();

        // where you can click
        minClick = GameObject.Find("Dates Panel").GetComponent<RectTransform>().rect.height;
        minClickPlus = minClick + panel.GetComponent<RectTransform>().rect.height;
        offset = GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height / 2;
    }

    // hide the source information
    private void Start()
    {
        panel.SetActive(false);
    }

    // zoom to the selected country/region
    public void ChooseCountry()
    {
        // if there's already a reference to an asset bundle, unload it
        if (countryBundle != null)
            countryBundle.Unload(true);

        // load the asset bundle for this country
        countryBundle = AssetBundle.LoadFromFile(
            Path.Combine(Application.streamingAssetsPath, countryName));

        if (countryBundle == null) // should not occur
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }

        simpleMap.localPosition = position; // corner
        panel.SetActive(false); // hide source panel
        zoomView.GetComponent<Image>().color = Color.white; // make zoomed map visible

        // set the image for the scroll view to the country that was just selected
        country.sprite = (countryBundle.LoadAsset<GameObject>(countryName)).GetComponent<Image>().sprite;
        country.SetNativeSize();
        SetSize(); // make sure the image fills the screen
        SetEnable(true); // empire map is clickable and animated

        // update source text
        sourceText.text = countryBundle.LoadAsset<TextAsset>(countryName + "-Source").text;
        sourceText.gameObject.GetComponent<TMPro.Examples.LinkHandler>().DisableLink();
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

    // called when user selects a new option in the dropdown list
    public void SelectDropdown(int val)
    {
        if (val > 0)
            submit.interactable = true;
        else // "no country selected"
            submit.interactable = false;
    }

    // zoom to selected country based on submission from dropdown list
    public void SetCountry()
    {
        countryName = options[countries.value].text;
        ChooseCountry();
    }

    // called when the user clicks on a country
    public void Hit(string name)
    {
        float min = minClick; // assuming source panel is closed
        if (panel.activeInHierarchy)
        {
            min = minClickPlus;
        }
        countryName = name;;
        if (ClickPos > min && !simpleButton.enabled && countries.GetComponentInChildren<ScrollRect>() == null)
        {
            ChooseCountry();
        }
    }

    // toggle settings for the empire map
    private void SetEnable(bool toggle)
    {
        simpleButton.enabled = toggle; // can I click on this map?
        simpleSize.enabled = toggle; // is it animated?
    }

    // called when user clicks on the empire map button
    public void Unzoom()
    {
        simpleMap.localScale = new Vector3(1, 1, 1); // back to normal size
        simpleMap.localPosition = new Vector3(1.5f, 50, 0); // back to center-ish position
        zoomView.GetComponent<Image>().color = new Color(255, 255, 255, 0); // hide zoom view
        SetEnable(false); // empire map is no longer clickable and animated
        sourceText.text = "<link=\"id_source\">https://upload.wikimedia.org/wikipedia/commons/e/e7/RomanEmpire_117.svg</link>";
        panel.SetActive(false);
        countryBundle.Unload(true);
    }

}
