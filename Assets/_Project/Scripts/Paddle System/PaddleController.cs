﻿using System;
using BrickBreak.Cameras;
using BrickBreak.Data;
using BrickBreak.GameManagement;
using BrickBreak.Singletons;
using UnityEngine;

namespace BrickBreak.Paddles
{
    /// <summary>
    /// The purpose of this class is to control the paddle, and update it's data based on predefined paddle data
    /// </summary>
    public class PaddleController : Singleton<PaddleController>    // Should probably NOT be a singleton..we need a better way to find this
    {
        // To avoid singleton, we could have an event called "RequestPaddle" that some gameobject fires which triggers an event on this gameobject
        // that sends this.gameobject as an arguement which might be weird but maybe worth it!?
        public PaddleData paddleData;

        #region Physics
        [Header("Physics")]
        [SerializeField] private Rigidbody2D paddleRigidBody = null;
        [SerializeField] private bool canMove = true;
        #endregion

        #region Screen
        [SerializeField] private float screenOffset = 0.0f;
        private float _horizontalMoveClamp;
        #endregion

        #region Input
        private float _horizontalInput = 0.0f;
        #endregion

        private void OnEnable()
        {
            GameplayManager.OnLevelCompleted += DisablePaddle;
        }

        private void OnDisable()
        {
            GameplayManager.OnLevelCompleted -= DisablePaddle;
        }

        private void Start()
        {
            _horizontalMoveClamp = MainCameraController.Instance.HorizontalScreenSize - screenOffset;
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
            position.x = Mathf.Clamp(position.x, -_horizontalMoveClamp, _horizontalMoveClamp);

            paddleRigidBody.MovePosition(position);
        }

        private void DisablePaddle()
        {
            canMove = false;
        }
        
    }
}