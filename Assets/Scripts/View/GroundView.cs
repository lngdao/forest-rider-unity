using System;
using UnityEngine;

public class GroundView : GameElement
{
    [SerializeField]
    private Renderer surface;


    private void Awake()
    {
        Vector3 surfaceSize = surface.bounds.size;
        Game.controller.ground.InitSurfaceSize(surfaceSize);
        Game.controller.ground.InitParent(this.transform);
        Game.controller.ground.SpawnTree(0, surfaceSize.z/2);
    }

    private void Start()
    {
        
    }
}

