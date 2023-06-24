using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;

    private bool saveData = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadPrefs();
    }

    private void LoadPrefs()
    {
        if (!PlayerPrefs.HasKey("hasLaunchedBefore"))
        {
            Debug.Log("First launch detected. Setting default values...");
            List<string> defaultRAMs = new List<string>();
            List<string> defaultGPUs = new List<string>();
            List<string> defaultStorages = new List<string>();
            List<string> defaultCoolings = new List<string>();

            defaultRAMs.Add("2GB DDR4");
            defaultGPUs.Add("");
            defaultStorages.Add("250GB HDD");
            defaultCoolings.Add("Omazing 212 EVO");
            defaultCoolings.Add("2x120mm");

            // Set default values
            PlayerPrefs.SetInt("hasLaunchedBefore", 1);
            PlayerPrefs.SetFloat("money", 0.0f);
            PlayerPrefs.SetFloat("lifetimeBalance", 0.0f);

            PlayerPrefs.SetInt("lifetimeXP", 0);
            PlayerPrefs.SetInt("saladChoppingTime", 0);
            PlayerPrefs.SetInt("currentDay", 0);
            PlayerPrefs.SetInt("currentHour", 0);
            PlayerPrefs.SetInt("currentMinute", 0);
            PlayerPrefs.SetFloat("last24Hrs", 0.0f);
            PlayerPrefs.SetInt("timeSpeed", 2);

            PlayerPrefs.SetString("currentCPU", "z3-8100");
            SaveStringList("currentRAMs", defaultRAMs);
            SaveStringList("currentGPUs", defaultGPUs);
            PlayerPrefs.SetString("currentMobo", "B260");
            PlayerPrefs.SetString("currentPSU", "250GB HDD");
            SaveStringList("currentStorages", defaultStorages);
            SaveStringList("currentCoolings", defaultCoolings);
            PlayerPrefs.SetString("currentCase", "Omazing Mini-ITX");

            PlayerPrefs.SetFloat("hardwarePower", 1f);

            PlayerPrefs.Save();
        }
    }

    public void ResetSave()
    {
        Debug.Log("Resetting save...");
        saveData = false;
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    private void SaveStringList(string key, List<string> stringList)
    {
        // Convert the list to a serialized string
        string serializedList = string.Join(",", stringList.ToArray());

        // Save the serialized string in PlayerPrefs
        PlayerPrefs.SetString(key, serializedList);
    }

    private void OnApplicationQuit()
    {
        if (!saveData) return;
        Debug.Log("Saving...");
        PlayerPrefs.SetInt("hasLaunchedBefore", 1);
        PlayerPrefs.SetFloat("money", GameManager.instance.Money);
        PlayerPrefs.SetFloat("lifetimeBalance", GameManager.instance.LifetimeBalance);

        PlayerPrefs.SetInt("lifetimeXP", GameManager.instance.LifetimeXP);
        PlayerPrefs.SetInt("saladChoppingTime", GameManager.instance.SaladChoppingTime);
        PlayerPrefs.SetInt("currentDay", GameManager.instance.CurrentDay);
        PlayerPrefs.SetInt("currentHour", GameManager.instance.CurrentHour);
        PlayerPrefs.SetInt("currentMinute", GameManager.instance.CurrentMinute);
        PlayerPrefs.SetFloat("last24Hrs", GameManager.instance.Last24Hrs);
        PlayerPrefs.SetInt("timeSpeed", GameManager.instance.timeSpeed);
        PlayerPrefs.SetFloat("hardwarePower", GameManager.instance.hardwarePower);

        PlayerPrefs.SetString("currentCPU", GameManager.instance.CurrentCPU);
        SaveStringList("currentRAMs", GameManager.instance.CurrentRAMs);
        SaveStringList("currentGPUs", GameManager.instance.CurrentGPUs);
        PlayerPrefs.SetString("currentMobo", GameManager.instance.CurrentMobo);
        PlayerPrefs.SetString("currentPSU", GameManager.instance.CurrentPSU);
        SaveStringList("currentStorages", GameManager.instance.CurrentStorages);
        SaveStringList("currentCoolings", GameManager.instance.CurrentCoolings);
        PlayerPrefs.SetString("currentCase", GameManager.instance.CurrentCase);
        PlayerPrefs.Save();
    }
}
