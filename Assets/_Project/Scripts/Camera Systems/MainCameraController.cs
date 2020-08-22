using System;
using System.Collections;
using BrickBreak.Singletons;
using UnityEngine;

namespace BrickBreak.Cameras
{
    // TODO: Rename this to Camera Controller, and have all of the cinemachine cameras we'll need to control
    public class MainCameraController : Singleton<MainCameraController>
    {
        public Camera mainCamera;

        private float _horizontalScreenSize;
        public float HorizontalScreenSize
        {
            get => _horizontalScreenSize;
            set => _horizontalScreenSize = value;
        }

        private float _verticalScreenSize;
        public float VerticalScreenSize
        {
            get => _verticalScreenSize;
            set => _verticalScreenSize = value;
        }

        protected override void Awake()
        {
            base.Awake();
            mainCamera = Camera.main;
            ScreenSizeUpdatedHandler();
        }

        private void OnEnable()
        {
            EventManager.StartListening("Brick Hit", ShakeCamera);
        }

        public void ScreenSizeUpdatedHandler()
        {
            if (mainCamera != null)
            {
                _verticalScreenSize = mainCamera.orthographicSize;
                _horizontalScreenSize = (_verticalScreenSize * Screen.width) / Screen.height;
            }
        }

        [ContextMenu("Shake the Camera")]
        private void ShakeCamera()
        {
            StartCoroutine(ShakeRoutine());
        }

        private IEnumerator ShakeRoutine()
        {
            yield break;
        }
    }
}