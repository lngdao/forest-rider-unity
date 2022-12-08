using System;
using UnityEngine;

public class PlayerView : GameElement
{
    [SerializeField]
    private new Rigidbody rigidbody;
    [SerializeField]
    private Transform truck;

    private void Update()
    {
        HandleOnInputEvent();
    }

    private void FixedUpdate()
    {
        Game.controller.player.HandleOnFixedUpdate(rigidbody, truck);
    }
     
    private void HandleOnInputEvent()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Game.controller.player.HandleOnInputEvent(truck, horizontal);
    }
}

