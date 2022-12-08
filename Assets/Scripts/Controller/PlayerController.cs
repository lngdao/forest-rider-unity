using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameElement
{
    public void HandleOnInputEvent(Transform truck, float horizontal)
    {
        Vector3 rotationLimit = Game.model.player.rotationLimit;
        truck.rotation = Quaternion.Euler(rotationLimit * horizontal);
    }

    public void HandleOnFixedUpdate(Rigidbody rigidbody, Transform truck)
    {
        //Vector3 direction = Game.model.player.direction;
        float speed = Game.model.player.speed;

        rigidbody.velocity = truck.forward * speed;
    }
}
