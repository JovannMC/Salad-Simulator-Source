using IngameDebugConsole;
using UnityEngine;

public class DebugConsole : MonoBehaviour
{
    [ConsoleMethod("setmoney", "Sets the player's money to the specified amount")]
    public static void SetMoney(float amount)
    {
        GameManager.instance.Money = amount;
        GameManager.instance.LifetimeBalance = amount;
    }
    [ConsoleMethod("addmoney", "Adds the specified amount to the player's money")]
    public static void AddMoney(float amount)
    {
        GameManager.instance.Money += amount;
        GameManager.instance.LifetimeBalance += amount;
    }
    [ConsoleMethod("removemoney", "Removes the specified amount from the player's money")]
    public static void RemoveMoney(float amount)
    {
        GameManager.instance.Money -= amount;
        GameManager.instance.LifetimeBalance -= amount;
    }

    [ConsoleMethod("settime", "Sets the game's time to the specified time")]
    public static void SetTime(int day, int hour, int minute)
    {
        GameManager.instance.CurrentDay = day;
        GameManager.instance.CurrentHour = hour;
        GameManager.instance.CurrentMinute = minute;
    }
    [ConsoleMethod("addtime", "Adds the specified amount of time to the game's time")]
    public static void AddTime(int day, int hour, int minute)
    {
        GameManager.instance.CurrentDay += day;
        GameManager.instance.CurrentHour += hour;
        GameManager.instance.CurrentMinute += minute;
    }
    [ConsoleMethod("removetime", "Removes the specified amount of time from the game's time")]
    public static void RemoveTime(int day, int hour, int minute)
    {
        GameManager.instance.CurrentDay -= day;
        GameManager.instance.CurrentHour -= hour;
        GameManager.instance.CurrentMinute -= minute;
    }

    [ConsoleMethod("setlifetimebalance", "Sets the player's lifetime balance to the specified amount")]
    public static void SetLifetimeBalance(float amount)
    {
        GameManager.instance.LifetimeBalance = amount;
    }
    [ConsoleMethod("addlifetimebalance", "Adds the specified amount to the player's lifetime balance")]
    public static void AddLifetimeBalance(float amount)
    {
        GameManager.instance.LifetimeBalance += amount;
    }
    [ConsoleMethod("removelifetimebalance", "Removes the specified amount from the player's lifetime balance")]
    public static void RemoveLifetimeBalance(float amount)
    {
        GameManager.instance.LifetimeBalance -= amount;
    }

    [ConsoleMethod("setsaladchoppingtime", "Sets the salad chopping time to the specified amount")]
    public static void SetSaladChoppingTime(int amount)
    {
        GameManager.instance.SaladChoppingTime = amount;
    }
    [ConsoleMethod("addsaladchoppingtime", "Adds the specified amount to the salad chopping time")]
    public static void AddSaladChoppingTime(int amount)
    {
        GameManager.instance.SaladChoppingTime += amount;
    }
    [ConsoleMethod("removesaladchoppingtime", "Removes the specified amount from the salad chopping time")]
    public static void RemoveSaladChoppingTime(int amount)
    {
        GameManager.instance.SaladChoppingTime -= amount;
    }

    [ConsoleMethod("setlifetimexp", "Sets the player's lifetime xp to the specified amount")]
    public static void SetLifetimeXP(int amount)
    {
        GameManager.instance.LifetimeXP = amount;
    }
    [ConsoleMethod("addlifetimexp", "Adds the specified amount to the player's lifetime xp")]
    public static void AddLifetimeXP(int amount)
    {
        GameManager.instance.LifetimeXP += amount;
    }
    [ConsoleMethod("removelifetimexp", "Removes the specified amount from the player's lifetime xp")]
    public static void RemoveLifetimeXP(int amount)
    {
        GameManager.instance.LifetimeXP -= amount;
    }

    [ConsoleMethod("settimespeed", "Sets the game's time speed. 1 = 10 minutes per second, 2 = 1 hour per second")]
    public static void SetTimeSpeed(int amount)
    {
        GameManager.instance.ToggleTimeSpeed();
    }
    [ConsoleMethod("sethardwarepower", "Sets the player's hardware power to the specified amount")]
    public static void SetHardwarePower(float amount)
    {
        GameManager.instance.hardwarePower = amount;
    }
    [ConsoleMethod("resetsave", "Resets the player's save")]
    public static void ResetSave()
    {
        SaveSystem.instance.ResetSave();
    }
}
