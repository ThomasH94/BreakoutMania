using System;
using System.Collections;
using System.Collections.Generic;
using BrickBreak.Data.Collectables;
using BrickBreak.Paddles;
using UnityEngine;

namespace BrickBreak.Collectables
{
    /// <summary>
    /// Collectables are any item the player can pickup that will increase the current score
    /// </summary>
    public class Collectable : MonoBehaviour, ICollectable
    {
        [SerializeField] private CollectableData _collectableData;
        [SerializeField] private SFXPlayer _sfxPlayer;
        private SpriteRenderer collectableSpriteRenderer;
        private Collider2D collectableCollider;

        public static event Action<int> OnAnyCollectable;

        protected void Start()
        {
            if (_sfxPlayer == null)
                _sfxPlayer = GetComponent<SFXPlayer>();
            collectableSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
            collectableCollider = GetComponent<Collider2D>();
        }


        public virtual void OnCollect()
        {
            OnAnyCollectable?.Invoke(_collectableData.scoreAmount);
            _sfxPlayer.sfxToPlay = _collectableData.collectSound;
            _sfxPlayer.PlaySFX();
            collectableSpriteRenderer.enabled = false;
            collectableCollider.enabled = false;
            Destroy(gameObject,2f);
        }
        

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PaddleController>())
                OnCollect();
        }
    }
}