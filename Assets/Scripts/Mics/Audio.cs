using System;
using UnityEngine;

[Serializable]
public class Audio
{
    public string name;
    public AudioClip clip;
    public float volume;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}

