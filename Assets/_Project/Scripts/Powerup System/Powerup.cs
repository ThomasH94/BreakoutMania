using System;
using BrickBreak.Data;
using BrickBreak.Paddles;
using UnityEngine;

 namespace BrickBreak.Collectables
 {
     public abstract class Powerup : Collectable, ICollectable
     {
         // Seperate powerups into timed and usage based - i.e. limited ammo
         [SerializeField] protected PowerupData powerupData;

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