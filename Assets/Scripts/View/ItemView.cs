using System;
using UnityEngine;

public class ItemView : GameElement
{
    private void Awake()
    {
        Game.controller.item.InitParent(this.transform);
    }
}