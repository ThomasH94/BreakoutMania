using BrickBreak.Collectibles;
using UnityEngine;

namespace BrickBreak.Powerups
{

    public class LimitedUsePowerup : Powerup, ILimitable
    {
        public int Uses { get; set; }
        [SerializeField] private int startingUses = 0;

        protected new virtual void Start()
        {
            Uses = startingUses;
        }
        

        public void Use()
        {
            Uses--;
            if (Uses == 0)
            {
                RemovePowerup();
            }
        }
    }
}