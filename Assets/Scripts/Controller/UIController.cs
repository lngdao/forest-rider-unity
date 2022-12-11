using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : GameElement
{
    private float _timeGame = 0;
    private int _scoreGame = 0;
    private int _heart = 3;
    private float _heartInterval = 30;
    private GameObject UIText;
    private GameObject UIButtonStart;
    private GameObject UIButtonPause;
    private GameObject UIButtonLose;

    public void InitUIComponent(GameObject UIText, GameObject UIButtonStart, GameObject UIButtonPause, GameObject UIButtonLose)
    {
        this.UIText = UIText;
        this.UIButtonStart = UIButtonStart;
        this.UIButtonPause = UIButtonPause;
        this.UIButtonLose = UIButtonLose;
        UIText.SetActive(false);
        UIButtonPause.SetActive(false);
    }

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

    public void HandleExitGame()
    {
        #if UNITY_STANDALONE
                Application.Quit();
        #endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void HandleStartGame()
    {
        UIText.SetActive(true);
        UIButtonStart.SetActive(false);
        Time.timeScale = 1;
        Game.controller.player.StartPlayer();
    }

    public void HandlePauseGame()
    {
        Time.timeScale = 0;
        UIButtonPause.SetActive(true);
        Game.controller.player.StopPlayer();
        //UIButton.transform.GetChild()
    }

    public void HandleResumeGame()
    {
        Time.timeScale = 1;
        UIButtonPause.SetActive(false);
    }

    public void HandleRestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void HandleLoseGame()
    {
        Time.timeScale = 0;
        UIText.transform.GetChild(3).gameObject.SetActive(false);
        UIButtonLose.SetActive(true);
    }
}
