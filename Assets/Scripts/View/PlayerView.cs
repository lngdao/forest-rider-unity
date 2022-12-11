using System;
using UnityEngine;

public class PlayerView : GameElement
{
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private Transform truck;
    [SerializeField] private Light lightFrontLeft;
    [SerializeField] private Light lightFrontRight;
    [SerializeField] private Light lightBackLeft;
    [SerializeField] private Light lightBackRight;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "GateEnter")
        {
            Game.controller.ground.InactivePreviousGround();
        } else if (other.gameObject.name == "GateExit")
        {
            Game.controller.ground.SpawnNextGround();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Heart" || collision.gameObject.tag == "Coin")
        {
            Game.controller.item.HandleOnPlayerEnter(collision.gameObject);
        } else if (collision.gameObject.tag == "Tree")
        {
            Game.controller.ui.HandleLoseGame();
        }
    }

    private void Awake()
    {
        //rigidbody = 
        Game.controller.player.InitLightComponent(lightFrontLeft, lightFrontRight, lightBackLeft, lightBackRight);
    }

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

