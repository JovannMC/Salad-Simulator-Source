using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject systemInfo;
    [SerializeField] private GameObject appearance;

    public void HidePages()
    {
        // Hide all pages
        GameObject[] pagesList = GameObject.FindGameObjectsWithTag("Setting");
        for (int i = 0; i < pagesList.Length; i++)
        {
            pagesList[i].SetActive(false);
        }
    }

    public void VisitPage(string targetPage)
    {
        HidePages();

        // Set URL and show target website
        switch (targetPage)
        {
            case "main":
                main.SetActive(true);
                break;
            case "systeminfo":
                systemInfo.SetActive(true);
                break;
            case "appearance":
                appearance.SetActive(true);
                break;
        }

    }
}