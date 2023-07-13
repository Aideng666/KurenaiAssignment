using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound._clip;

            sound.source.volume = sound._volume;
            sound.source.pitch = sound._pitch;
            sound.source.loop = sound._loop;
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Play("MenuTheme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found! Make sure you spelt it correctly!");
            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found! Make sure you spelt it correctly!");
            return;
        }

        s.source.Stop();
    }

    public void ChangeMusicVolume(float value)
    {
        AudioListener.volume = value;
    }
}

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip _clip;

    [Range(0f, 1f)]
    public float _volume;
    [Range(0.1f, 3f)]
    public float _pitch;

    public bool _loop;

    [HideInInspector]
    public AudioSource source;
}
