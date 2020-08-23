using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Collectables are any item the player can pickup that will increase the current score
/// </summary>
public class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField] private CollectableData _collectableData;
    public void OnCollect()
    {
        //ScoreController.Instance.
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        throw new System.NotImplementedException();
    }
}
