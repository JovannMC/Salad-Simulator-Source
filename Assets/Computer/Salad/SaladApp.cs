using System.Collections.Generic;
using System.Collections;
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

    // Underlines
    [Header("Underlines")]
    [SerializeField] private GameObject earnBtnUnderline;
    [SerializeField] private GameObject performanceBtnUnderline;
    [SerializeField] private GameObject notificationBtnUnderline;

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
    [SerializeField] private TMP_Text balanceText;
    [SerializeField] private TMP_Text last24HrsText;
    [SerializeField] private TMP_Text next24HrsText;
    [SerializeField] private TMP_Text currentJobText;

    // Performance tab
    [Header("Performance tab")]
    [SerializeField] private GameObject cpuCard;
    [SerializeField] private GameObject hardwarePrefab;

    private float[] last24Hours = new float[24];

    // Earn tab
    public void ToggleSalad()
    {
        if (GameManager.instance.SaladChopping)
        {
            GameManager.instance.SaladChopping = false;
            runningImg.SetActive(false);

            choppingBtn.GetComponent<CircleGraphic>().color = new Color32(30, 51, 68, 255);
            startImg.SetActive(true);

            statusBg.GetComponent<Image>().color = Color.white;
            statusText.text = "Paused";
            StopCoroutine("AddMoney");
        } else
        {
            GameManager.instance.SaladChopping = true;
            startImg.SetActive(false);

            choppingBtn.GetComponent<CircleGraphic>().color = new Color32(178, 213, 48, 255);
            runningImg.SetActive(true);

            statusBg.GetComponent<Image>().color = new Color32(178, 213, 48, 255);
            statusText.text = "Running";
            StartCoroutine("AddMoney");
        }
    }

    public void AddToPerformance(string hardwareName, string hardwareType) 
    {
        if (hardwareType == "CPU") {
            cpuCard.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = hardwareName;
        } else if (hardwareType == "GPU") {
            GameObject hardware = Instantiate(hardwarePrefab, hardwarePrefab.transform.parent);
            hardware.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = hardwareName;
            hardware.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Icons/graphic-card");
            hardware.SetActive(true);
        }
        
    }

    public void OpenTab(string tab)
    {
        switch (tab)
        {
            case "earn":
                earnTab.GetComponent<TextMeshProUGUI>().color = new Color32(178, 213, 48, 255);
                earnContent.SetActive(true);
                earnBtnUnderline.SetActive(true);

                performanceTab.GetComponent<TextMeshProUGUI>().color = new Color32(204, 226, 182, 255);
                performanceContent.SetActive(false);
                performanceBtnUnderline.SetActive(false);
                notificationTab.GetComponent<Image>().color = new Color32(204, 226, 182, 255);
                notificationContent.SetActive(false);
                notificationBtnUnderline.SetActive(false);
                pfpContent.SetActive(false);
                break;
            case "performance":
                performanceTab.GetComponent<TextMeshProUGUI>().color = new Color32(178, 213, 48, 255);
                performanceContent.SetActive(true);
                performanceBtnUnderline.SetActive(true);

                earnTab.GetComponent<TextMeshProUGUI>().color = new Color32(204, 226, 182, 255);
                earnContent.SetActive(false);
                earnBtnUnderline.SetActive(false);
                notificationTab.GetComponent<Image>().color = new Color32(204, 226, 182, 255);
                notificationContent.SetActive(false);
                notificationBtnUnderline.SetActive(false);
                pfpContent.SetActive(false);
                break;
            case "notifications":
                notificationTab.GetComponent<Image>().color = new Color32(178, 213, 48, 255);
                notificationContent.SetActive(true);
                notificationBtnUnderline.SetActive(true);

                earnTab.GetComponent<TextMeshProUGUI>().color = new Color32(204, 226, 182, 255);
                earnContent.SetActive(false);
                earnBtnUnderline.SetActive(false);
                performanceTab.GetComponent<TextMeshProUGUI>().color = new Color32(204, 226, 182, 255);
                performanceContent.SetActive(false);
                performanceBtnUnderline.SetActive(false);
                pfpContent.SetActive(false);
                break;
            case "pfp":
                pfpContent.SetActive(true);
                break;
        }
    }

    IEnumerator AddMoney()
    {
        while (GameManager.instance.SaladChopping)
        {
            yield return new WaitForSeconds(1);
            if (GameManager.instance.TimeSpeed == 1)
            {
                GameManager.instance.Money += GameManager.instance.MoneyPerMinute * 10;
                last24Hours[GameManager.instance.CurrentHour] = GameManager.instance.MoneyPerMinute * 10;
            } else if (GameManager.instance.TimeSpeed == 2)
            {
                GameManager.instance.Money += GameManager.instance.MoneyPerMinute * 60;
                last24Hours[GameManager.instance.CurrentHour] = GameManager.instance.MoneyPerMinute * 60;
            }
            float last24Hrs = 0;
            for (int i = 0; i < last24Hours.Length; i++)
            {
                if (last24Hours[i] != 0) {
                    last24Hrs += last24Hours[i];
                }
            }

            float next24Hrs = GameManager.instance.MoneyPerMinute * 60 * 24;
            balanceText.text = "$" + GameManager.instance.Money.ToString("0.00");
            last24HrsText.text = "+ $" + last24Hrs.ToString("0.00");
            next24HrsText.text = "+ $" + next24Hrs.ToString("0.00");
            currentJobText.text = GameManager.instance.CurrentJob;
        }
    }

}

