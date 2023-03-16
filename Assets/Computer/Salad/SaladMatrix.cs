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
        {"rendering", 5f},
        {"machine learning", 6f},
        {"ai training", 8f},
        {"data mining", 4f},
        {"data processing", 6.5f},
        {"data analysis", 4.5f},
        {"data visualization", 4f},
        {"web scraping", 2f},
    };

    private string currentJob = "waiting";
    private float currentJobEarnings = 0.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start() 
    {
        baseEarnings = 1.0f;
        StartCoroutine(SelectJob());
        StartCoroutine(UpdateMarketDemand());
        StartCoroutine(Earnings());
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
        }
    }

    IEnumerator UpdateMarketDemand() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
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
                Debug.Log("New job! " + currentJob + " with earnings: " + currentJobEarnings.ToString());
            }
        }
    }
}
