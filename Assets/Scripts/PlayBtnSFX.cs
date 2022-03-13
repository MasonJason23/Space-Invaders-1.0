using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayBtnSFX : MonoBehaviour
{
    private AudioSource btnAudioSrc;

    public void Start()
    {
        btnAudioSrc = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        btnAudioSrc.Play();
    }
}
