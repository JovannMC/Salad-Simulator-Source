using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JobManager : MonoBehaviour
{
    public static JobManager instance;
    [SerializeField] private GameObject cooldownPrompt;
    private bool jobCooldown = false;

    // Job, Pay per hour
    private Dictionary<string, float> jobTypes = new Dictionary<string, float>()
    {
        {"Babysitter", 9.50f},
        {"Janitor", 10.50f},
        {"Cashier", 12.00f},
        {"Server", 14.50f},
        {"Tutor", 15.50f},
        {"Bartender", 16.50f},
        {"Chef", 19.50f},
        {"Manager", 22.00f},
    };

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
    }

    private void Update() 
    {
        if (GameManager.instance.CurrentHour == 0)
        {
            jobCooldown = false;
        }
    }

    public void StartJob(string job, int hours)
    {
        if (jobTypes.ContainsKey(job))
        {
            if (jobCooldown)
            {
                StartCoroutine(Cooldown());
                return;
            }

            GameManager.instance.Money += jobTypes[job] * hours;
            
            if (GameManager.instance.CurrentHour + hours > 24) {
                GameManager.instance.CurrentDay += 1;
                GameManager.instance.CurrentHour = (GameManager.instance.CurrentHour + hours) - 24;
            } else {
                GameManager.instance.CurrentHour += hours;
            }

            jobCooldown = true;
        }
    }

    private IEnumerator Cooldown()
    {
        if (!GameManager.instance.isNoticeActive)
        {
            GameManager.instance.isNoticeActive = true;
            cooldownPrompt.SetActive(true);
            yield return new WaitForSeconds(3f);
            cooldownPrompt.SetActive(false);
            GameManager.instance.isNoticeActive = false;
        }
    }

    public string GetRandomJob()
    {
        return jobTypes.ElementAt(Random.Range(0, jobTypes.Count)).Key;
    }

    public int GetRandomHours()
    {
        return Random.Range(1, 9);
    }

    public float GetPayPerHour(string job)
    {
        return jobTypes[job];
    }

    public float GetFinalPay(string job, float hours)
    {
        return jobTypes[job] * hours;
    }
}
