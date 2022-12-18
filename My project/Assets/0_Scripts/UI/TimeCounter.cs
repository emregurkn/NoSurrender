using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public float timeRemaining;
    public bool timerOn = false;
    public TextMeshProUGUI timerText;
    public Button restartButton;

    void Start()
    {
        timerOn = false;
    }


    void Update()
    {
        CalculateRemainingTime();
    }

    public void CalculateRemainingTime()
    {
        if (timerOn)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimer(timeRemaining);
            }
            else
            {
                SetActiveRestartButton();
                timeRemaining = 0;
                timerOn = false;
            }
        }
    }

    public void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void SetActiveRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }
}
