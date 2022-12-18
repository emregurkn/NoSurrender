using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

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

    private IEnumerator TimeCounter()
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
        countDownText.gameObject.SetActive(false);
        timeCounter.timerOn = true;
    }
}
