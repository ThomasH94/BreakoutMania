using System;
using System.Collections.Generic;
using BrickBreak.Ball;
using BrickBreak.Data;
using BrickBreak.EventManagement;
using BrickBreak.Paddles;
using BrickBreak.Singletons;
using Unity.Mathematics;
using UnityEngine;

namespace BrickBreak.GameManagement
{

    public class BallManager : Singleton<BallManager>
    {
        public List<BallController> AllBalls { get; set; }
        private BallController _defaultBall;
        [SerializeField] private BallController ballPrefab = null;
        private Rigidbody2D _defaultBallRigidBody;
        public Action<Vector2> getPaddlePosition;


        private void Start()
        {
            RespawnBall();
        }

        private void OnEnable()
        {
            BallController.OnAnyBallDestroyed += RemoveAnyBall;
        }

        private void OnDisable()
        {
            BallController.OnAnyBallDestroyed -= RemoveAnyBall;
        }

        private void RespawnBall()
        {
            float yOffset = 0.16f;
            Vector2 paddlePosition = PaddleController.Instance.transform.position;
            Vector2 ballStartPosition =
                new Vector2(paddlePosition.x,
                    paddlePosition.y + yOffset); // Use the paddles position and move up slightly

            // Create and setup ball if we don't have one
            if (_defaultBall == null)
            {
                _defaultBall = Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);
                _defaultBallRigidBody = _defaultBall.GetComponent<Rigidbody2D>();

                // Add it to the list of balls, needed for multi-ball
                AllBalls = new List<BallController>() {_defaultBall};
            }

            _defaultBall.transform.position = ballStartPosition;
            _defaultBall.transform.parent = PaddleController.Instance.transform;
            _defaultBall.SetBallToServe();
        }

        // Used by the Snap Ball Powerup
        public void SnapBall(BallController snappedBall)
        {
            _defaultBall = snappedBall;
            RespawnBall();
        }

        private void AddBall()
        {
            //TODO: Used for Multi-Ball Power Up
        }

        public void RemoveAnyBall(BallController ballToRemove)
        {
            AllBalls.Remove(ballToRemove);
            if (AllBalls.Count <= 0)
            {
                _defaultBall = null;

                EventManager.TriggerEvent("Lose Life");
                if (LivesManager.Instance.Lives > 0)
                {
                    RespawnBall();
                }
            }
        }

        // Used by the Multi-Ball Powerup
        public void SpawnBalls(Vector3 transformPosition, int amount, BallData data)
        {
            Vector2 multiBallForce = new Vector2(0, data.moveSpeed);


            for (int i = 0; i < amount; i++)
            {
                // Create new balls based on the amount, give them a force, and add them to our ball list
                float spawnOffset = UnityEngine.Random.Range(-0.5f, 0.5f) + i;
                Vector2 spawnPosition = new Vector2(transformPosition.x + spawnOffset, transformPosition.y);

                BallController spawnedBall = Instantiate(ballPrefab, transformPosition, quaternion.identity);
                spawnedBall.name = "MultiBall " + i;
                spawnedBall.ballData = data; // Give this new ball the multi-ball data

                AllBalls.Add(spawnedBall);
                spawnedBall.ServeBall();

                Rigidbody2D spawnedRigidbody = spawnedBall.GetComponent<Rigidbody2D>();
                spawnedRigidbody.velocity = multiBallForce;

            }
        }
    }
}