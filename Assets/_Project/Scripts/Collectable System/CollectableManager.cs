using System;
using System.Collections.Generic;
using BrickBreak.Breakable;
using BrickBreak.Collectables;
using BrickBreak.Data;
using BrickBreak.Singletons;
using Unity.Mathematics;
using UnityEngine;

public class CollectableManager : Singleton<CollectableManager>
{
    public List<PowerupData> allPowerups;
    public List<PowerupData> allPowerdowns;
    
    private List<Powerup> activePowerups;

    [Range(0,100)]
    public float PowerupSpawnChance;
    [Range(0,100)]
    public float PowerdownSpawnChance;

    private void OnEnable()
    {
        Brick.OnAnyBrickDied += OnAnyBrickDestroyedHandler;
    }

    private void OnAnyBrickDestroyedHandler(Brick destroyedBrick)
    {
        
    }

    private Powerup CheckPowerupChance()
    {
        return null;
    }

    public void SpawnPowerup()
    {
        Powerup powerupToSpawn = CheckPowerupChance();
        if (powerupToSpawn != null)
        {
            powerupToSpawn = (Powerup) Instantiate(powerupToSpawn, Vector3.back, Quaternion.identity);
        }
    }
    

    private void OnAnyPowerupTriggeredHandler()
    {
        
    }

    private void RemovePowerups()
    {
        foreach (Powerup powerupComponent in activePowerups)
        {
            
        }
    }
}