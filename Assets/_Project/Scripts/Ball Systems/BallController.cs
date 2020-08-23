using System;
using BrickBreak.Data;
using BrickBreak.Paddles;
using UnityEngine;

namespace BrickBreak.Ball
{
    public class BallController : MonoBehaviour
    {
        public BallData ballData;
        private float _moveSpeed;

        [Header("Physics")]
        
        [SerializeField] private Rigidbody2D ballRigidBody = null;
        public bool _ballServed = false;

        #region Events
        public static event Action<BallController> OnAnyBallDestroyed;
        #endregion


        void Start()
        {
            SetupBall();
        }
        

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !_ballServed)
            {
                ServeBall();
            }
        }
        

        public void SetupBall()
        {
            // Used for getting components, setting graphics, and more
            _moveSpeed = ballData.moveSpeed;
            if (ballRigidBody == null)
                ballRigidBody = GetComponent<Rigidbody2D>();
        }

        // Sets the ball up to be served, which is different than actually setting up the ball
        public void SetBallToServe()
        {
            _ballServed = false;
            ballRigidBody.simulated = false;    // To fix issues with parenting
        }

        public void ServeBall()
        {
            _ballServed = true;
            transform.parent = null;
            ballRigidBody.simulated = true;
            ballRigidBody.velocity = Vector2.up * _moveSpeed;
        }

        private void OnCollisionEnter2D(Collision2D collidedObj)
        {
            // Ball has a reference to the paddle so we may be able to avoid this..
            if(collidedObj.gameObject.GetComponent<PaddleController>())
            {
                float maxVelocity = 1.5f;    //Limit the ball from flying to fast if hit from the side of the paddle

                float hitForce = HitFactor(transform.position,
                    collidedObj.transform.position, collidedObj.collider.bounds.size.x);
                
                Debug.Log($"Hit force:{hitForce}");

                Vector2 hitDirection = new Vector2(hitForce, 1).normalized;
                hitDirection.x = Mathf.Clamp(hitDirection.x, -maxVelocity, maxVelocity);
                hitDirection *= _moveSpeed;

                ballRigidBody.velocity = hitDirection;

                Debug.Log($"Velocity:{ballRigidBody.velocity}");
            }
        }

        /// <summary>
        /// When the ball hits the paddle, we need to decide where to send it based on the angle it hit from
        /// We can check the x position of the ball and paddle, then subtract them
        /// Finally, divide that by the width of the paddle (which can grow with power ups)
        /// </summary>
        /// <param name="ballPosition"></param>
        /// <param name="paddlePosition"></param>
        /// <param name="paddleWidth"></param>
        /// <returns></returns>
        private float HitFactor(Vector2 ballPosition, Vector2 paddlePosition, float paddleWidth)
        {
            // Visual example:
            // || -0.5     0      0.5    <- x Position after subtraction
            // || ===================    <- Paddle
            
            float hitDirectionHorizontal = (ballPosition.x - paddlePosition.x) / paddleWidth;
            float randomXOffset = UnityEngine.Random.Range(0.1f, 0.4f);
            
            if (hitDirectionHorizontal < 0)
                randomXOffset *= -1;    // Move left if hitDirectionHorizontal is negative, right if positive

            return (hitDirectionHorizontal + randomXOffset);
        }

        public void DestroyBall()
        {
            OnAnyBallDestroyed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}