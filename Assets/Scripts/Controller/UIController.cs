using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : GameElement
{
    private float _timeGame = 0;
    private int _scoreGame = 0;
    private int _heart = 3;
    private float _heartInterval = 10;

    public void HandleUpdateTimeGame(TMPro.TextMeshProUGUI timeUI)
    {
        //_timeGame += Time.deltaTime;
        timeUI.text = "Time: " + _timeGame.ToString("F0");
    }

    public void HandleUpdateScoreGame(TMPro.TextMeshProUGUI scoreUI)
    {
        scoreUI.text = "Score: " + _scoreGame.ToString("F0");
    }

    public void HandleCheckHeathPlayer(TMPro.TextMeshProUGUI heartUI)
    {
        string text = "";
        if (_heart == 1) text = "B";
        else if (_heart == 2) text = "B B";
        else if (_heart == 3) text = "B B B";
        else text = "";

        heartUI.text = text;
    }

    public void HandleAddScoreGame(int score)
    {
        _scoreGame += score;
    }

    public void HandleAddHeathPlayer()
    {
        if (_heart == 3) { return; }
        if (_heart + 1 > 3)
        {
            _heart = 3;
            return;
        } 
        _heart += 1;
        _heartInterval = 15;
    }

    private void Awake()
    {
        StartCoroutine(CycleUpdateHeath());
        InvokeRepeating("UpdateScorePerSecond", 1.0f, 1.0f);
        InvokeRepeating("UpdateTimePerSecond", 1.0f, 1.0f);
    }

    public IEnumerator CycleUpdateHeath()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            HandleHeathInterval();
        }
    }

    private void UpdateScorePerSecond()
    {
        _scoreGame += 1;
    }

    private void UpdateTimePerSecond()
    {
        _timeGame += 1;
    }

    private void HandleHeathInterval()
    {
        _heartInterval -= 1;
        if (_heartInterval == 0)
        {
            _heart -= 1;
            _heartInterval = 5;
        }
    }
}
