using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

/// <summary>
/// Start timer variables and functionalities
///
/// Takes care of:
///     - keeping the variables and functionalities of start time
/// <summary>

public class StartTimer : MonoBehaviour
{
    private int waitSecond = 3;
    public bool startGame;
    public TextMeshProUGUI countDownText;
    private TimeCounter timeCounter;


    void Start()
    {
        timeCounter = GetComponent<TimeCounter>();
        startGame = false;
        StartCoroutine(TimeCounter());
    }

    private IEnumerator TimeCounter() //Provides the countdown at the beginning of the game. 
    {
        while (waitSecond > 0)
        {
            countDownText.text = waitSecond.ToString();
            countDownText.gameObject.transform.DOScale(Vector3.one * 3, 0.5f).SetEase(Ease.OutSine).OnComplete(() =>
            {
                countDownText.gameObject.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.OutSine);
            });
            yield return new WaitForSeconds(1);
            waitSecond -= 1;
        }
        startGame = true;
        countDownText.gameObject.SetActive(false); //After the time runs out, the game starts.
        timeCounter.timerOn = true;
    }
}
