using BrickBreak.Singletons;
using UnityEngine;

namespace BrickBreak.Cameras
{
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

        public void ScreenSizeUpdatedHandler()
        {
            if (mainCamera != null)
            {
                _verticalScreenSize = mainCamera.orthographicSize;
                _horizontalScreenSize = (_verticalScreenSize * Screen.width) / Screen.height;
            }
        }
    }
}