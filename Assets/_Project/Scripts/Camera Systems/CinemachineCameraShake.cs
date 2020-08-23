using System;
using Cinemachine;
using UnityEngine;

public class CinemachineCameraShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private CinemachineBasicMultiChannelPerlin cineMachinePerlin;
    private float shakeTimer = 0;

    private void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        cineMachinePerlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void OnEnable()
    {
        EventManager.StartListening("Brick Hit", ShakeCamera);
    }
    
    private void OnDisable()
    {
        EventManager.StopListening("Brick Hit", ShakeCamera);
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                // Stop shaking
                cineMachinePerlin.m_AmplitudeGain = 0;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShakeCamera();
        }
    }

    [ContextMenu("Shake the Camera")]
    private void ShakeCamera()
    {
        float intensity = UnityEngine.Random.Range(0.2f,0.5f);
        float shakeTime = UnityEngine.Random.Range(0.1f,0.15f);

        cineMachinePerlin.m_AmplitudeGain = intensity;
        shakeTimer = shakeTime;
    }
}
