using System.Collections;
using TMPro;
using Unity.VisualScripting;
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

    // PC
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
}
