﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetermineIncome : MonoBehaviour
{
    [SerializeField] private int startingInterval = 20;
    [SerializeField] private int intervalIncrease = 10;
    [SerializeField] private int startingIncome = 100;
    [SerializeField] private int incomeIncrease = 100;

    private int currentInterval;
    private int stepsRemaining;
    private int currentIncome;

    private void Awake()
    {
        currentInterval = startingInterval;
        stepsRemaining = currentInterval;
        currentIncome = startingIncome;
    }

    public void DecreaseSteps()
    {
        stepsRemaining--;
        if (stepsRemaining <= 0)
        {
            IncreaseIncome();
            IncreaseInterval();
            VisualFeedback();
        }
    }

    private void IncreaseIncome()
    {
        currentIncome += incomeIncrease;
    }

    private void IncreaseInterval()
    {
        currentInterval += intervalIncrease;
        stepsRemaining = currentInterval;
    }

    public int GetCurrentIncome()
    {
        return currentIncome;
    }

    private void VisualFeedback()
    {
        // TODO feedback
        Debug.Log("Salary Increased!");
    }
}
