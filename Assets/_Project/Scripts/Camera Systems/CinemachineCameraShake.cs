using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CinemachineCameraShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    private float shakeTimer = 0;

    private void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                // Stop shaking
                CinemachineBasicMultiChannelPerlin cineMachinePerlin =
                    _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cineMachinePerlin.m_AmplitudeGain = 0;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShakeCamera(0.4f, 0.1f);
        }
    }

    [ContextMenu("Shake the Camera")]
    private void ShakeCamera(float intensity, float shakeTime)
    {
        CinemachineBasicMultiChannelPerlin cineMachinePerlin =
            _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cineMachinePerlin.m_AmplitudeGain = intensity;
        shakeTimer = shakeTime;
    }
}
