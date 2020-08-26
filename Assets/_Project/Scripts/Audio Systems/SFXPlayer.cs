using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrickBreak.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SFXPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource sfxSource;

        public AudioClip sfxToPlay;
        
        private void Start()
        {
            sfxSource = GetComponent<AudioSource>();
        }

        public void PlaySFX()
        {
            sfxSource.clip = sfxToPlay;
            sfxSource.PlayOneShot(sfxToPlay);
        }
    }
}