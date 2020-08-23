using System;
using System.Collections;
using BrickBreak.Ball;
using BrickBreak.Utility;
using UnityEngine;

namespace BrickBreak.Breakable
{

    public class Brick : MonoBehaviour, IDamagable, ISetupable
    {
        // Could have brick types that give you points, light up, and maybe stuff like glass that subtracts points
        
        public static event Action<Brick> OnAnyBrickDied; 

        public BrickData brickData;
        public int Health { get; set; }

        [Header("Presentation")] private SFXPlayer _sfxPlayer;

        private void Start()
        {
            Setup(brickData);
            _sfxPlayer = GetComponent<SFXPlayer>();
        }
        
        public void Setup(ScriptableObject data)
        {
            if (data != null)
                data = brickData;

            Health = brickData.Health;

            Collider2D brickCollider = GetComponent<Collider2D>();
            brickCollider.sharedMaterial = brickData.brickPhysicsMaterial;
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<BallController>())
            {
                TakeDamage();
            }
        }

        public void TakeDamage(int damageAmount = 1)
        {
            _sfxPlayer.PlaySFX();
            EventManager.TriggerEvent("Brick Hit");

            Health -= damageAmount;
            if (Health <= 0)
            {
                // Destroy and add points -- play animation and sounds on hit
                OnAnyBrickDied?.Invoke(this);

                Die();
            }
            else
            {
                // If we aren't dead, then start breaking  
                Debug.Log("Crumble");
            }
        }

        public void Die()
        {
            Destroy(gameObject, 0.1f); // Currently, we are not pooling this object, so we'll destroy it
        }
        
        private void Crumble()
        {
            //TODO: Check the brick datas crumble sprites and update via Crumble Routine
            // This method will Crumble for bricks, leak light for lights, or match the current themes sprite breakage
        }

        private IEnumerator CrumbleRoutine()
        {
            // Enable the next crumble sprite
            yield return null;
        }
    }
}