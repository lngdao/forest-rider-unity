using System;
using UnityEngine;
using UnityEngine.UI;

public class UIView : GameElement
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreUI;
    [SerializeField] private TMPro.TextMeshProUGUI timeUI;
    [SerializeField] private TMPro.TextMeshProUGUI heartUI;

    private void Update()
    {
        Game.controller.ui.HandleUpdateTimeGame(timeUI);
        Game.controller.ui.HandleUpdateScoreGame(scoreUI);
        Game.controller.ui.HandleCheckHeathPlayer(heartUI);
    }
}