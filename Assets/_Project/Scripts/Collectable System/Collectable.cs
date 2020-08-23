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

        public static event Action<int> OnAnyCollectable;


        public virtual void OnCollect()
        {
            OnAnyCollectable?.Invoke(_collectableData.scoreAmount);
            Destroy(gameObject);
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PaddleController>())
                OnCollect();
        }
    }
}