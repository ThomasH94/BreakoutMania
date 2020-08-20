using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrickBreak.Paddles
{
    public class PaddleController : MonoBehaviour
    {
        public PaddleData paddleData;
        [SerializeField] private Rigidbody2D paddleRigidBody;
        [SerializeField] private bool canMove = true;
        [SerializeField] private float screenBoundary;

        #region Input

        private float _horizontalInput = 0.0f;

        #endregion

        private void Start()
        {

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
            position.x = Mathf.Clamp(position.x, -screenBoundary, screenBoundary);

            paddleRigidBody.MovePosition(position);
        }
    }
}