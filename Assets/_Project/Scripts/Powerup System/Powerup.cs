using BrickBreak.Data;
using BrickBreak.Paddles;
using UnityEngine;

 namespace BrickBreak.Collectables
 {
     public abstract class Powerup : Collectable, ICollectable
     {
         // Seperate powerups into timed and usage based - i.e. limited ammo
         [SerializeField] protected PowerupData powerupData;

         public override void OnCollect()
         {
             ApplyPowerup();
             base.OnCollect();
         }

         protected virtual void ApplyPowerup()
         {

         }

         public void OnTriggerEnter2D(Collider2D other)
         {
             if (other.gameObject.GetComponent<PaddleController>())
             {
                 OnCollect();
             }
         }
     }
 }