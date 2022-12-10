using System.Collections;
using UnityEngine;

public class DayNightCycle : GameElement
{
    [SerializeField] private float rotateSpeed = 0.03f;
    [SerializeField] private float cycleSpeed;
    [SerializeField] private float xRotation;
    private new Light light;
    private float intensity = 2;

    private void Start()
    {
        light = GetComponent<Light>();
        StartCoroutine(Cycle());
    }

    public IEnumerator Cycle()
    {
        while(true)
        {
            yield return new WaitForSeconds(cycleSpeed);
            Rotate();
        }
    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(-1, 0, 0) * rotateSpeed);
        xRotation = transform.rotation.eulerAngles.x;
        if (xRotation > 200)
        {
            Game.controller.player.TurnOnLight();
            light.intensity = 0;
        } else
        {
            Game.controller.player.TurnOffLight();
            light.intensity = intensity;
        }
    }
}

