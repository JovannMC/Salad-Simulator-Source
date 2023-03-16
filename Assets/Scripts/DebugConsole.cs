using IngameDebugConsole;
using UnityEngine;

public class DebugConsole : MonoBehaviour
{
    [ConsoleMethod("setmoney", "Sets the player's money to the specified amount")]
    public static void SetMoney(float amount)
    {
        GameManager.instance.Money = amount;
    }
    [ConsoleMethod("addmoney", "Adds the specified amount to the player's money")]
    public static void AddMoney(float amount)
    {
        GameManager.instance.Money += amount;
    }
    [ConsoleMethod("removemoney", "Removes the specified amount from the player's money")]
    public static void RemoveMoney(float amount)
    {
        GameManager.instance.Money -= amount;
    }
    [ConsoleMethod("settimespeed", "Sets the game's time speed. 1 = 10 minutes per second, 2 = 1 hour per second")]
    public static void SetTimeSpeed(int amount)
    {
        GameManager.instance.TimeSpeed = amount;
    }
    [ConsoleMethod("sethardwarepower", "Sets the player's hardware power to the specified amount")]
    public static void SetHardwarePower(float amount)
    {
        GameManager.instance.hardwarePower = amount;
    }
}
