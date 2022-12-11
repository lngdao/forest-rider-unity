using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : GameElement
{
    [SerializeField] Audio[] audios;

    private void Awake()
    {
        foreach (Audio audio in audios)
        {
            audio.source = gameObject.AddComponent<AudioSource>();
            audio.source.clip = audio.clip;
            audio.source.volume = audio.volume;
            audio.source.loop = audio.loop;
        }
    }

    private void Start()
    {
        PlayAudio("Theme");
    }

    public void PlayAudio(string soundName)
    {
        Audio audio = Array.Find(audios, sound => sound.name == soundName);
        if (audio != null)
        {
            audio.source.Play();
        }
    }
}

