using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameElement
{
    private Light lightFrontLeft;
    private Light lightFrontRight;
    private Light lightBackLeft;
    private Light lightBackRight;

    public void InitLightComponent(Light frontLeft, Light frontRight, Light backLeft, Light backRight)
    {
        this.lightFrontLeft = frontLeft;
        this.lightFrontRight = frontRight;
        this.lightBackLeft = backLeft;
        this.lightBackRight = backRight;
    }

    public void TurnOnLight()
    {
        this.lightFrontLeft.intensity = 200;
        this.lightFrontRight.intensity = 200;
        this.lightBackLeft.intensity = 0.2f;
        this.lightBackRight.intensity = 0.2f;
    }

    public void TurnOffLight()
    {
        this.lightFrontLeft.intensity = 0;
        this.lightFrontRight.intensity = 0;
        this.lightBackLeft.intensity = 0;
        this.lightBackRight.intensity = 0;
    }

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
