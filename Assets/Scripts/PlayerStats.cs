using System;
using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public int startMoney = 400;
    public int startLives = 20;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
}