using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer Instance;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip[] _audioClips;

    public void AddPoints()
    {
        _source.clip = _audioClips[0];
        _source.Play();
    }

    public void BlockBumping()
    {
        _source.clip = _audioClips[1];
        _source.Play();
    }

    public void FinishLevel()
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = _audioClips[2];
        source.volume = 0.2f;
        source.Play();
    }




}
