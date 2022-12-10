using System;
using UnityEngine;

public class PlayerModel : GameElement
{
    [SerializeField] public float speed = 5f;
    [SerializeField] public Vector3 direction = Vector3.forward;
    [SerializeField] public Vector3 rotationLimit = new Vector3(0, 30, 0);
}

