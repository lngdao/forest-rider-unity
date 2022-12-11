using System;
using UnityEngine;
using UnityEngine.UI;

public class UIView : GameElement
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreUI;
    [SerializeField] private TMPro.TextMeshProUGUI timeUI;
    [SerializeField] private TMPro.TextMeshProUGUI heartUI;
    [SerializeField] private GameObject UIText;
    [SerializeField] private GameObject UIButtonStart;
    [SerializeField] private GameObject UIButtonPause;
    [SerializeField] private GameObject UIButtonLose;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void Start()
    {
        Game.controller.ui.InitUIComponent(UIText, UIButtonStart, UIButtonPause, UIButtonLose);
    }

    private void Update()
    {
        Game.controller.ui.HandleUpdateTimeGame(timeUI);
        Game.controller.ui.HandleUpdateScoreGame(scoreUI);
        Game.controller.ui.HandleCheckHeathPlayer(heartUI);
    }

    public void OnStartButtonClick()
    {
        Game.controller.ui.HandleStartGame();
    }

    public void OnPauseButtonClick()
    {
        Game.controller.ui.HandlePauseGame();
    }

    public void OnResumeButtonClick()
    {
        Game.controller.ui.HandleResumeGame();
    }

    public void OnRestartButtonClick()
    {
        Game.controller.ui.HandleRestartGame();
    }

    public void OnExitButtonClick()
    {
        Game.controller.ui.HandleExitGame();
    }
}