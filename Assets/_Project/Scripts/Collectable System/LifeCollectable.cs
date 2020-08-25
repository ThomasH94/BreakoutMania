using BrickBreak.Collectables;
using UnityEngine;

public class LifeCollectable : Collectable
{
    [SerializeField] private int livesAmount = 1;
    public override void OnCollect()
    {
        LivesManager.Instance.GainLives(livesAmount);
        base.OnCollect();
    }
}