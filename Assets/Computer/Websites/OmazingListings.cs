using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class OmazingListings : MonoBehaviour
{
    private TMP_Text listingName;
    private TMP_Text listingPrice;
    private GameObject listingImage;

    private string newListingName;
    private string newListingPrice;
    private Image newListingImage;

    private void Awake()
    {
        string type = gameObject.transform.parent.transform.parent.transform.parent.name;
        string hardwareName = gameObject.name;

        // Get text components
        TMP_Text listingName = transform.Find("Name").GetComponent<TMP_Text>();
        TMP_Text listingPrice = transform.Find("Price").GetComponent<TMP_Text>();
        GameObject listingImage = transform.Find("Image").gameObject;
        listingImage.GetComponent<Image>().color = Color.black;

        listingName.text = hardwareName;
        listingPrice.text = "Price: $" + Hardware.price[listingName.text].ToString();
        
        switch (type) 
        {
            case "CPU":
                listingImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/Hardware/cpu");
                break;
            case "RAM":
                listingImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/Hardware/ram");
                break;
            case "GPU":
                listingImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/Hardware/gpu");
                break;
            case "Motherboard":
                listingImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/Hardware/mobo");
                break;
            case "PSU":
                listingImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/Hardware/psu");
                break;
            case "Storage":
                listingImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/Hardware/storage");
                break;
            case "Cooling":
                listingImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/Hardware/cooling");
                break;
            case "Case":
                listingImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/Hardware/case");
                break;
        }
    }
}
