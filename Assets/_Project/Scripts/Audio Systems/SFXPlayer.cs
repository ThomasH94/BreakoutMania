using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource sfxSource;

    [SerializeField] private AudioClip sfxToPlay = null;
    // Start is called before the first frame update
    void Start()
    {
        sfxSource = GetComponent<AudioSource>();
    }

    public void PlaySFX()
    {
        sfxSource.PlayOneShot(sfxToPlay);
    }
    
}