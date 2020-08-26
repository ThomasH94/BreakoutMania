using System;
using BrickBreak.GameManagement;
using BrickBreak.Singletons;
using UnityEngine;

namespace BrickBreak.Audio
{
    [RequireComponent(typeof(AudioSource))] // TODO: Move to the IAudible Interface as well as SFXPlayer
    public class MusicPlayer : Singleton<MusicPlayer>
    {

        private AudioSource _musicSource;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            SceneController.OnLevelWasLoaded += PlayMusic;
        }

        private void OnDisable()
        {
            SceneController.OnLevelWasLoaded -= PlayMusic;
        }

        private void Start()
        {
            _musicSource = GetComponent<AudioSource>();
        }

        private void PlayMusic()
        {
            if (!_musicSource.isPlaying)
                _musicSource.Play();
        }
    }
}