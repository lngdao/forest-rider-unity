using System;
using UnityEngine;

public class GroundModel : GameElement
{
    [SerializeField] public GameObject surfacePrefab;
    [SerializeField] public GameObject[] treesPrefab;
    [SerializeField] public float zRangeMin = 4;
    [SerializeField] public float zRangeMax = 7;
    [SerializeField] public float xRange = 3.2f;
    [SerializeField] public float yPosition = 0.15f;
}

