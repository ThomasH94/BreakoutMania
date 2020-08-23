using UnityEngine;

[RequireComponent(typeof(AudioSource))]    // TODO: Move to the IAudible Interface as well as SFXPlayer
public class MusicPlayer : MonoBehaviour
{
    private float _audioTime = 0f;
    
    [SerializeField] private float loopStart = 0f;
    [SerializeField] private float loopEnd = 0f; 

    private AudioSource _musicSource;

    private void Start()
    {
        _musicSource = GetComponent<AudioSource>();
    }

    private void PlayMusic()
    {
        _musicSource.Play();
    }


    private void Update()
    {
        _audioTime += Time.deltaTime;
        if (_audioTime >= loopEnd)
        {
            _audioTime = loopStart;
        }
    }
}
