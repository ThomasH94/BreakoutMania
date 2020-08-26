using System;
using BrickBreak.Data;
using BrickBreak.Paddles;
using UnityEngine;

 namespace BrickBreak.Collectibles
 {
     public abstract class Powerup : Collectible, ICollectible
     {
         public static Action<Powerup> OnAnyPowerupTriggered;

         public override void OnCollect()
         {
             ApplyPowerup();
             base.OnCollect();
         }

         protected virtual void ApplyPowerup()
         {
            OnAnyPowerupTriggered?.Invoke(this);
         }

         protected virtual void RemovePowerup()
         {
             
         }

     }
 }