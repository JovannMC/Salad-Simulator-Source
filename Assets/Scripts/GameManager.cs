using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float money { get; set; }

    [SerializeField] private TMP_Text moneyText;

    // Time
    [SerializeField] private TMP_Text TimeText;
    private bool timeRunning { get; set; }
    private int currentDay { get; set; }
    private int currentHour { get; set; }
    private int currentMinute { get; set; }
    public int timeSpeed = 2;

    // Salad
    private bool saladChopping { get; set; }
    private float moneyPerMinute { get; set; }
    private string currentJob { get; set; }

    // PC
    private string currentCPU { get; set; }
    private List<string> currentRAMs = new List<string>();
    private List<string> currentGPUs = new List<string>();
    private string currentMobo { get; set; }
    private string currentPSU { get; set; }
    private List<string> currentStorages = new List<string>();
    private List<string> currentCoolings = new List<string>();
    private string currentCase { get; set; }

    public float hardwarePower = 1f;

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

    public void Start()
    {
        timeRunning = true;
        currentDay = 1;
        currentHour = 0;
        currentMinute = 0;

        InvokeRepeating("UpdateTime", 0, 1);
    }

    public void Update()
    {
        moneyText.text = "Money: " + money.ToString("0.00");

        //moneyPerMinute = moneyPerMinuteEditor;

        if (timeSpeed == 0)
        {
            timeRunning = false;
        } else
        {
            timeRunning = true;
        }
    }

    // Time system
    private void UpdateTime()
    {
        if (timeRunning)
        {
            if (timeSpeed == 1)
            {
                // 1 real life second = 10 minutes in game
                currentMinute += 10;

                if (currentMinute >= 60)
                {
                    currentMinute = 0;
                    currentHour += 1;
                    Debug.Log("New hour - Hour " + currentHour);
                }

                if (currentHour >= 24)
                {
                    currentHour = 0;
                    currentDay += 1;
                    Debug.Log("New day - Day " + currentDay);
                }
                TimeText.text = "Time: " + currentDay + "d " + currentHour + "h " + currentMinute + "m";
            }
            else if (timeSpeed == 2)
            {
                // 1 real life second = 1 hour in game
                currentHour += 1;

                Debug.Log("New hour - Hour " + currentHour);
                if (currentHour >= 24)
                {
                    currentHour = 0;
                    currentDay += 1;
                    Debug.Log("New day - Day " + currentDay);
                }
                TimeText.text = "Time: " + currentDay + "d " + currentHour + "h " + currentMinute + "m";
            }
        }
    }

    // Getters and setters
    public float Money
    {
        get { return money; }
        set { money = value; }
    }

    public float MoneyPerMinute
    {
        get { return moneyPerMinute; }
        set { moneyPerMinute = value; }
    }

    public bool TimeRunning
    {
        get { return timeRunning; }
        set { timeRunning = value; }
    }

    public int CurrentDay
    {
        get { return currentDay; }
        set { currentDay = value; }
    }

    public int CurrentHour
    {
        get { return currentHour; }
        set { currentHour = value; }
    }

    public int CurrentMinute
    {
        get { return currentMinute; }
        set { currentMinute = value; }
    }

    public int TimeSpeed
    {
        get { return timeSpeed; }
        set { timeSpeed = value; }
    }

    public bool SaladChopping
    {
        get { return saladChopping; }
        set { saladChopping = value; }
    }

    public string CurrentJob
    {
        get { return currentJob; }
        set { currentJob = value; }
    }

    // PC Hardware
    public string CurrentCPU
    {
        get { return currentCPU; }
        set { currentCPU = value; }
    }

    public List<string> CurrentRAMs
    {
        get { return currentRAMs; }
        set { currentRAMs = value; }
    }

    public List<string> CurrentGPUs
    {
        get { return currentGPUs; }
        set { currentGPUs = value; }
    }

    public string CurrentMobo
    {
        get { return currentMobo; }
        set { currentMobo = value; }
    }

    public string CurrentPSU
    {
        get { return currentPSU; }
        set { currentPSU = value; }
    }

    public List<string> CurrentStorages
    {
        get { return currentStorages; }
        set { currentStorages = value; }
    }

    public List<string> CurrentCoolings
    {
        get { return currentCoolings; }
        set { currentCoolings = value; }
    }

    public string CurrentCase
    {
        get { return currentCase; }
        set { currentCase = value; }
    }

}
