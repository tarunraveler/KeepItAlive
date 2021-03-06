﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseJeweler : MonoBehaviour
{
    [SerializeField] private int moneyCost = 1000;
    [SerializeField] private float heartCapGainAmount = 1f;
    [SerializeField] private float feedbackIntensity = 5f;

    public void OnUseBuilding()
    {
        if (!GameManager.Instance.GetIsHeartMaxed())
        {
            if (GameManager.Instance.GetCurrentMoney() >= moneyCost)
            {
                GameManager.Instance.SpendMoney(moneyCost);
                FloatingTextController.Instance.CreateFloatingText("-" + moneyCost.ToString(), FloatingTextController.Instance.moneyColor, GameManager.Instance.moneyIcon.position);

                VisualFeedback();
                AudioManager.Instance.PlaySound("UseJeweler");

                GameManager.Instance.IncreaseHeartCap(heartCapGainAmount);
                FloatingTextController.Instance.CreateFloatingText("+" + heartCapGainAmount.ToString(), Color.white, GameManager.Instance.heartIcon.position);
            }
            else
            {
                AudioManager.Instance.PlaySound("NegativeFeedback");
                FloatingTextController.Instance.CreateFloatingText("Need $" + moneyCost.ToString(), FloatingTextController.Instance.negativeColor, FloatingTextController.Instance.wordSize, transform.position);
            }
        }
        else
        {
            AudioManager.Instance.PlaySound("NegativeFeedback");
            FloatingTextController.Instance.CreateFloatingText("Lovin' maxed!", FloatingTextController.Instance.heartColor, FloatingTextController.Instance.wordSize, transform.position);
        }
    }

    private void VisualFeedback()
    {
        Camera.main.GetComponent<Shake>().ShakeCamera(feedbackIntensity);
        GetComponent<Building>().SpawnToken();
    }
}
