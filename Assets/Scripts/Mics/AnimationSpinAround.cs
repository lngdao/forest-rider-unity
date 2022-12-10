using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AnimationSpinAround : GameElement
{
    [SerializeField]
    private float _rotationSpin = 150f;

    void Update()
    {
        transform.Rotate(Vector3.up * _rotationSpin * Time.deltaTime);
    }
}

