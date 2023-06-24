using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaladMatrix : MonoBehaviour
{
    public static SaladMatrix instance;

    private float baseEarnings = 0.0001f;
    private float marketDemand = 1.0f;

    private Dictionary<string, float> jobTypes = new Dictionary<string, float>()
    {
        {"Rendering", 5f},
        {"ML algorithm training", 6f},
        {"AI data analysis", 7f},
        {"AI training", 8f},
        {"Data mining", 4f},
        {"Data processing", 6.5f},
        {"Data analysis", 4.5f},
        {"Data visualization", 4f},
        {"Web scraping", 2f},
        {"Natural language processing", 5f},
        {"Image recognition", 5.5f},
        {"Simulation modeling", 6f},
        {"Quantum computing research", 8.5f},
        {"Statistical analysis", 4.5f},
        {"Algorithm optimization", 7f},
        {"Cryptocurrency mining", 3.5f},
        {"Network packet analysis", 6f},
        {"Bioinformatics research", 7f},
        {"Climate modeling", 6.5f},
        {"Financial market prediction", 5.5f},
        {"Game physics simulation", 4f}
    };

    private string currentJob = "None";
    private float currentJobEarnings = 0.0f;

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
    }

    private void Start()
    {
        StartCoroutine(SelectJob());
        StartCoroutine(UpdateMarketDemand());
        StartCoroutine(Earnings());
        GameManager.instance.CurrentJob = currentJob;
    }

    IEnumerator Earnings()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            // if salad is chopping
            if (GameManager.instance.SaladChopping)
            {
                // Calculate final earnings
                float earnings = ((baseEarnings * currentJobEarnings) * GameManager.instance.hardwarePower) * marketDemand;

                // debug messages
                Debug.Log("Job: " + currentJob + " earning " + currentJobEarnings + " marketDemand: " + marketDemand.ToString("0.00") + " hardwarePower: " + GameManager.instance.hardwarePower.ToString());
                Debug.Log("Earnings: " + earnings.ToString());

                // Send earnings to SaladApp
                GameManager.instance.MoneyPerMinute = earnings;
            }

            if (!GameManager.instance.SaladChopping)
            {
                currentJob = "None";

                currentJobEarnings = 0.0f;
                GameManager.instance.CurrentJob = currentJob;
            }
        }
    }

    IEnumerator UpdateMarketDemand()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));
            marketDemand = Random.Range(1, 1.4f);
        }
    }

    IEnumerator SelectJob()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(18, 48));
            if (GameManager.instance.SaladChopping)
            {
                // Select a random job
                List<string> keys = new List<string>(jobTypes.Keys);
                int randomIndex = Random.Range(0, keys.Count);

                currentJob = keys[randomIndex];
                currentJobEarnings = jobTypes[currentJob];
                GameManager.instance.CurrentJob = currentJob;
                Debug.Log("New job! " + currentJob + " with earnings: " + currentJobEarnings.ToString());
            }
        }
    }
}
