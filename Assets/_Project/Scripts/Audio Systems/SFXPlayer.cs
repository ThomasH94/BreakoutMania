using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource sfxSource;
    public AudioClip sfxToPlay;
    // Start is called before the first frame update
    void Start()
    {
        sfxSource = GetComponent<AudioSource>();
    }

    public void PlaySFX()
    {
        sfxSource.clip = sfxToPlay;
        sfxSource.PlayOneShot(sfxToPlay);
    }
    
}