using System;
using BrickBreak.Data;
using BrickBreak.Paddles;
using UnityEngine;

 namespace BrickBreak.Collectables
 {
     public abstract class Powerup : Collectable, ICollectable
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
         
     }
 }