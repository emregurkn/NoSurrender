using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


/// <summary>
/// Remaining timer variables and functionalities
///
/// Takes care of:
///     - keeping the variables and functionalities of time counter
/// <summary>


public class TimeCounter : MonoBehaviour
{
    public float timeRemaining;
    public bool timerOn = false; //Stop and start remaining time counter.
    public TextMeshProUGUI timerText;
    public Button restartButton;


    void Start()
    {
        timerOn = false; // At the start it is false, because it waits for start timer finish its job.
    }


    void Update()
    {
        CalculateRemainingTime();
    }

    public void CalculateRemainingTime()//Calculate remaining time
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

    public void UpdateTimer(float currentTime)//Set the timer variable as a clock counter
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void SetActiveRestartButton()//Activate restart button when time is finish.
    {
        restartButton.gameObject.SetActive(true);
    }
}
