using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaladApp : MonoBehaviour
{
    // Tabs
    [Header("Tabs")]
    [SerializeField] private GameObject earnTab;
    [SerializeField] private GameObject performanceTab;
    [SerializeField] private GameObject notificationTab;

    // Outlines
    [Header("Outlines")]
    [SerializeField] private GameObject earnBtnOutline;
    [SerializeField] private GameObject performanceBtnOutline;
    [SerializeField] private GameObject notificationBtnOutline;

    // Content
    [Header("Content")]
    [SerializeField] private GameObject earnContent;
    [SerializeField] private GameObject performanceContent;
    [SerializeField] private GameObject notificationContent;
    [SerializeField] private GameObject pfpContent;

    // Earn tab
    [Header("Earn tab")]
    [SerializeField] private GameObject choppingBtn;
    [SerializeField] private GameObject startImg;
    [SerializeField] private GameObject runningImg;
    [SerializeField] private GameObject statusBg;
    [SerializeField] private TMP_Text statusText;

    private bool saladChopping = false;

    // Earn tab
    public void ToggleSalad()
    {
        if (saladChopping)
        {
            saladChopping = false;
            runningImg.SetActive(false);

            choppingBtn.GetComponent<CircleGraphic>().color = new Color32(30, 51, 68, 255);
            startImg.SetActive(true);

            statusBg.GetComponent<Image>().color = Color.white;
            statusText.text = "Paused";
        } else
        {
            saladChopping = true;
            startImg.SetActive(false);

            choppingBtn.GetComponent<CircleGraphic>().color = new Color32(178, 213, 48, 255);
            runningImg.SetActive(true);

            statusBg.GetComponent<Image>().color = new Color32(178, 213, 48, 255);
            statusText.text = "Running";
        }
    }

    public void OpenTab(string tab)
    {
        switch (tab)
        {
            case "earn":
                earnTab.GetComponent<TextMeshProUGUI>().color = new Color32(178, 213, 48, 255);
                earnContent.SetActive(true);
                earnBtnOutline.SetActive(true);

                performanceTab.GetComponent<TextMeshProUGUI>().color = new Color32(204, 226, 182, 255);
                performanceContent.SetActive(false);
                performanceBtnOutline.SetActive(false);
                notificationTab.GetComponent<Image>().color = new Color32(204, 226, 182, 255);
                notificationContent.SetActive(false);
                notificationBtnOutline.SetActive(false);
                pfpContent.SetActive(false);
                break;
            case "performance":
                performanceTab.GetComponent<TextMeshProUGUI>().color = new Color32(178, 213, 48, 255);
                performanceContent.SetActive(true);
                performanceBtnOutline.SetActive(true);
                
                earnTab.GetComponent<TextMeshProUGUI>().color = new Color32(204, 226, 182, 255);
                earnContent.SetActive(false);
                earnBtnOutline.SetActive(false);
                notificationTab.GetComponent<Image>().color = new Color32(204, 226, 182, 255);
                notificationContent.SetActive(false);
                notificationBtnOutline.SetActive(false);
                pfpContent.SetActive(false);
                break;
            case "notifications":
                notificationTab.GetComponent<Image>().color = new Color32(178, 213, 48, 255);
                notificationContent.SetActive(true);
                notificationBtnOutline.SetActive(true);

                earnTab.GetComponent<TextMeshProUGUI>().color = new Color32(204, 226, 182, 255);
                earnContent.SetActive(false);
                earnBtnOutline.SetActive(false);
                performanceTab.GetComponent<TextMeshProUGUI>().color = new Color32(204, 226, 182, 255);
                performanceContent.SetActive(false);
                performanceBtnOutline.SetActive(false);
                pfpContent.SetActive(false);
                break;
            case "pfp":
                pfpContent.SetActive(true);
                break;
        }
    }
}
