using TMPro;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject systemInfo;
    [SerializeField] private GameObject appearance;

    [Header("System Info")]
    [SerializeField] private TMP_Text cpuText;
    [SerializeField] private TMP_Text ramText;
    [SerializeField] private TMP_Text gpuText;
    [SerializeField] private TMP_Text moboText;
    [SerializeField] private TMP_Text psuText;
    [SerializeField] private TMP_Text storageText;
    [SerializeField] private TMP_Text coolingText;
    [SerializeField] private TMP_Text caseText;
    [SerializeField] private TMP_Text hardwarePowerText;

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
                SetSystemInfo();
                systemInfo.SetActive(true);
                break;
            case "appearance":
                appearance.SetActive(true);
                break;
        }

    }

    private void SetSystemInfo()
    {
        cpuText.text = GameManager.instance.CurrentCPU;
        ramText.text = string.Join(", ", GameManager.instance.CurrentRAMs);
        gpuText.text = string.Join(", ", GameManager.instance.CurrentGPUs);
        moboText.text = GameManager.instance.CurrentMobo;
        psuText.text = GameManager.instance.CurrentPSU;
        storageText.text = string.Join(", ", GameManager.instance.CurrentStorages);
        coolingText.text = string.Join(", ", GameManager.instance.CurrentCoolings);
        caseText.text = GameManager.instance.CurrentCase;
        hardwarePowerText.text = GameManager.instance.hardwarePower.ToString();
    }
}