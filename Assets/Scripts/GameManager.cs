using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float money { get; set; }

    // Salad
    private float defaultMoneyPerHour = 0.13f;
    private float moneyPerHour { get; set; }


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
       moneyPerHour = defaultMoneyPerHour;
    }

    public float Money
    {
        get { return money; }
        set { money = value; }
    }

    public float MoneyPerHour
    {
        get { return moneyPerHour; }
        set { moneyPerHour = value; }
    }
}
