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

        public BrickData _brickData;
        public int Health { get; set; }

        [Header("Presentation")] private SFXPlayer _sfxPlayer;

        private void Start()
        {
            Setup(_brickData);
            _sfxPlayer = GetComponent<SFXPlayer>();
        }
        
        public void Setup(ScriptableObject brickData)
        {
            if (brickData != null)
                brickData = _brickData;

            Health = _brickData.Health;

            Collider2D brickCollider = GetComponent<Collider2D>();
            brickCollider.sharedMaterial = _brickData.brickPhysicsMaterial;
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<BallController>())
            {
                TakeDamage();
            }
        }

        public void TakeDamage()
        {
            _sfxPlayer.PlaySFX();
            EventManager.TriggerEvent("Brick Hit");

            Health--;
            if (Health <= 0)
            {
                // Destroy and add points -- play animation and sounds on hit
                if (BrickManager.Instance != null)
                {
                    BrickManager.Instance.BrickDestroyed(_brickData);
                }

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
            if (ShouldSpawnCollectable())
            {
                SpawnCollectable();
            }
            
            Destroy(gameObject, 0.1f); // Currently, we are not pooling this object, so we'll destroy it
        }

        private bool ShouldSpawnCollectable()
        {
            return false;
        }

        public void SpawnCollectable()
        {
            //TODO: Spawn a collectable from the collectables list based on weight
        }

        private void Crumble()
        {
            //TODO: Check the brick datas crumble sprites and update via Crumble Routine
            // This method will Crumble for bricks, leak light for lights, or match the current themes sprite breakage
        }

        private IEnumerator CrumbleRoutine()
        {
            // Slowly fade into the new crumble sprite and out of the old one
            yield return null;
        }
    }
}