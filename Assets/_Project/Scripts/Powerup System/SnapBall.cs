using BrickBreak.GameManagement;
using UnityEngine;

namespace BrickBreak.Powerups
{

    public class SnapBall : MonoBehaviour, ILimitable
    {
        private BallDetector _ballDetector;
        public int snapCount = 3;
        public int Uses { get; set; }


        private void Start()
        {
            if (_ballDetector == null)
                _ballDetector = GetComponent<BallDetector>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Snap();
            }
        }

        public void Snap()
        {
            if (_ballDetector.ball)
            {
                BallManager.Instance.SnapBall(_ballDetector.ball);
                UpdateSnapCount(-1);
            }
        }

        public void UpdateSnapCount(int amount)
        {
            snapCount += amount;
            if (snapCount > 3)
                snapCount = 3;

            if (snapCount <= 0)
                DestroyPowerup();
        }

        private void DestroyPowerup()
        {
            Destroy(gameObject);
        }

        public void Use()
        {

        }
    }
}