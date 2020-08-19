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
        public bool usePhysics = true;

        #region Input

        private float _horizontalInput = 0.0f;

        #endregion

        private void Start()
        {

        }

        private void Update()
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal"); // Read input in update so we don't miss any inputs
            if(usePhysics)
                return;
            Vector2 moveVector = new Vector2(_horizontalInput * paddleData.moveSpeed, 0);
            transform.Translate(moveVector.x * Time.deltaTime, moveVector.y, 0);
        }

        private void FixedUpdate()
        {
            if(!usePhysics)
                return;
            
            Vector2 moveVector = new Vector2(_horizontalInput,0).normalized;
            paddleRigidBody.MovePosition((Vector2) transform.position + moveVector * (paddleData.moveSpeed * Time.deltaTime));

        }
    }
}