using System;
using TMPro;
using UnityEngine;

public class BrowserManager : MonoBehaviour
{
    [SerializeField] private TMP_Text urlText;

    [SerializeField] private GameObject home;
    [SerializeField] private GameObject salad;
        [SerializeField] private GameObject saladLoadingScreen;
    [SerializeField] private GameObject omazing;
    [SerializeField] private GameObject soafen;
    [SerializeField] private GameObject femboyfurry;
    [SerializeField] private GameObject cyph;

    public string currentWebsite { get; set; }

    public void HideWebsites()
    {
        // Hide all websites
        GameObject[] websitesList = GameObject.FindGameObjectsWithTag("Website");
        for (int i = 0; i < websitesList.Length; i++)
        {
            websitesList[i].SetActive(false);
        }
    }

    public void VisitWebsite(string targetWebsite)
    {
        HideWebsites();

        // Set URL and show target website
        switch (targetWebsite)
        {
            case "home":
                urlText.text = "";
                home.SetActive(true);
                break;
            case "salad":
                urlText.text = "https://salad.com";
                saladLoadingScreen.SetActive(true);
                salad.SetActive(true);
                break;
            case "omazing":
                urlText.text = "https://omazing.com";
                omazing.SetActive(true);
                break;
            case "soafen":
                urlText.text = "https://soafen.love";
                soafen.SetActive(true);
                break;
            case "femboyfurry":
                urlText.text = "https://femboyfurry.net";
                femboyfurry.SetActive(true);
                break;
            case "cyph":
                urlText.text = "https://cyph.codes";
                cyph.SetActive(true);
                break;
        }
        // Set active website
        currentWebsite = urlText.text;

    }
}
