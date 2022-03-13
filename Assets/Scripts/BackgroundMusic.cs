using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource myAudioSrc;

    private void Start()
    {
        myAudioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Player.setActive)
        {
            myAudioSrc.Stop();
        }
    }
}
