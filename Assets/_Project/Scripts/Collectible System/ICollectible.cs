using UnityEngine;

namespace BrickBreak.Collectibles
{
    public interface ICollectible
    {
        void OnCollect();
        void OnTriggerEnter2D(Collider2D other);
    }
}