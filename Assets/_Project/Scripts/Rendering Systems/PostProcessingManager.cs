using System.Collections;
using BrickBreak.Collectibles;
using BrickBreak.Singletons;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


namespace BrickBreak.PostProcessing
{
    public class PostProcessingManager : Singleton<PostProcessingManager>
    {
        private VolumeProfile profile;
        [SerializeField] private ChromaticAberration _chromaticAberration;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);

        }

        private void OnEnable()
        {
            Powerup.OnAnyPowerupTriggered += PlayPowerupFX;
        }

        private void Start()
        {
            profile = GetComponent<Volume>().profile;
            profile.TryGet(out _chromaticAberration);
            DisableAllPostProcessing();
        }

        private void DisableAllPostProcessing()
        {
            _chromaticAberration.active = false;
        }

        [ContextMenu("Power Up!")]
        public void PlayPowerupFX(Powerup powerup)
        {
            StartCoroutine(PowerUpFXRoutine());
        }

        private IEnumerator PowerUpFXRoutine()
        {
            float maxIntensity = 1.0f;
            float currentIntensity = 0f;

            _chromaticAberration.intensity.Override(currentIntensity);
            _chromaticAberration.active = true;

            while (currentIntensity < maxIntensity)
            {
                currentIntensity += Time.deltaTime * 2;
                _chromaticAberration.intensity.Override(currentIntensity);
                yield return null;
            }

            float timeBeforeDisable = 0.2f;
            yield return new WaitForSeconds(timeBeforeDisable);

            while (currentIntensity > timeBeforeDisable)
            {
                currentIntensity -= Time.deltaTime * 3;
                _chromaticAberration.intensity.Override(currentIntensity);
                yield return null;
            }

            _chromaticAberration.intensity.Override(0);
            _chromaticAberration.active = false;

        }
    }
}