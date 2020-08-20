using BrickBreak.Cameras;
using UnityEngine;

namespace BrickBreak.Paddles
{
    /// <summary>
    /// The purpose of this class is to control the paddle, and update it's data based on predefined paddle data
    /// </summary>
    public class PaddleController : MonoBehaviour
    {
        public PaddleData paddleData;

        #region Physics
        [Header("Physics")]
        [SerializeField] private Rigidbody2D paddleRigidBody = null;
        [SerializeField] private bool canMove = true;
        #endregion

        #region Screen
        [SerializeField] private float screenOffset;
        private float _screenBoundary;
        #endregion

        #region Input
        private float _horizontalInput = 0.0f;
        #endregion

        private void Start()
        {
            _screenBoundary = MainCameraController.Instance.HorizontalScreenSize - screenOffset;
        }

        private void Update()
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal"); // Read input in update so we don't miss any inputs
        }

        private void FixedUpdate()
        {
           MovePaddle();
        }

        private void MovePaddle()
        {
            if(!canMove)
                return;
            
            Vector2 moveVector = new Vector2(_horizontalInput,0).normalized;

            Vector2 position = (Vector2)transform.position + moveVector * (paddleData.moveSpeed * Time.deltaTime);
            position.x = Mathf.Clamp(position.x, -_screenBoundary, _screenBoundary);

            paddleRigidBody.MovePosition(position);
        }
    }
}