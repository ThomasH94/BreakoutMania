using BrickBreak.GameManagement;
using UnityEngine;

namespace BrickBreak.Collectibles
{

    public class LifeCollectible : Collectible
    {
        [SerializeField] private int livesAmount = 1;

        public override void OnCollect()
        {
            LivesManager.Instance.GainLives(livesAmount);
            base.OnCollect();
        }
    }
}