using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameElement
{
    private Light lightFrontLeft;
    private Light lightFrontRight;
    private Light lightBackLeft;
    private Light lightBackRight;
    private float speed = 0;

    float speedRate = 1f;

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

    private void IncreaseSpeedDependTime()
    {
        if (speed >= 20.0f) speed = 20.0f;
        else speed += speedRate;

        Debug.Log(speed);
    }

    public void StartPlayer()
    {
        speed = Game.model.player.speed;
        StartCoroutine(CycleUpdateSpeed());
        //InvokeRepeating("IncreaseSpeedDependTime", 10.0f, 1.0f);

    }

    public void StopPlayer()
    {
        speed = 0;
        //CancelInvoke();
        StopCoroutine(CycleUpdateSpeed());
    }

    public IEnumerator CycleUpdateSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            if (speed >= 30.0f) speed = 30.0f;
            else speed += speedRate;

            Debug.Log(speed);
        }
    }

    public void HandleOnFixedUpdate(Rigidbody rigidbody, Transform truck)
    {
        //Vector3 direction = Game.model.player.direction;
        //float speed = Game.model.player.speed;

        rigidbody.velocity = truck.forward * speed;
    }
}
