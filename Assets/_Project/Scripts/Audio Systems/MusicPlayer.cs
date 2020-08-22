using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private float audioTime = 0f;
    
    [SerializeField] private float loopStart;
    [SerializeField] private float loopEnd;

    private AudioSource musicSource;

    private void PlayMusic()
    {
        musicSource.Play();
    }


    private void Update()
    {
        audioTime += Time.deltaTime;
        if (audioTime >= loopEnd)
        {
            audioTime = loopStart;
        }
    }
}
