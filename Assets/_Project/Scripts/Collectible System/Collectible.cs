using System;
using System.Collections;
using System.Collections.Generic;
using BrickBreak.Audio;
using BrickBreak.Data.Collectibles;
using BrickBreak.Paddles;
using UnityEngine;

namespace BrickBreak.Collectibles
{
    /// <summary>
    /// Collectibles are any item the player can pickup that will increase the current score
    /// </summary>
    public class Collectible : MonoBehaviour, ICollectible
    {
        [SerializeField] private CollectibleData collectibleData = null;
        [SerializeField] private SFXPlayer _sfxPlayer = null;
        private SpriteRenderer collectibleSpriteRenderer;
        private Collider2D collectibleCollider;

        public static event Action<int> OnAnyCollectible;

        protected void Start()
        {
            if (_sfxPlayer == null)
                _sfxPlayer = GetComponent<SFXPlayer>();
            collectibleSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
            collectibleCollider = GetComponent<Collider2D>();
        }


        public virtual void OnCollect()
        {
            OnAnyCollectible?.Invoke(collectibleData.scoreAmount);
            _sfxPlayer.sfxToPlay = collectibleData.collectSound;
            _sfxPlayer.PlaySFX();
            collectibleSpriteRenderer.enabled = false;
            collectibleCollider.enabled = false;
            Destroy(gameObject,2f);
        }
        

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PaddleController>())
                OnCollect();
        }
    }
}