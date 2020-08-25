using System.Collections.Generic;
using BrickBreak.Breakable;
using BrickBreak.Collectables;
using BrickBreak.Data;
using BrickBreak.Data.Collectables;
using BrickBreak.Singletons;
using UnityEngine;

public class CollectableManager : Singleton<CollectableManager>
{
    public List<CollectableData> allCollectables;

    private List<Powerup> activePowerups;

    private void OnEnable()
    {
        Brick.OnAnyBrickDied += OnAnyBrickDestroyedHandler;
    }

    private void OnAnyBrickDestroyedHandler(Brick destroyedBrick)
    {
        // Should a collectable be spawned?
        int spawnCollectable = Random.Range(0, 3);
        if (spawnCollectable < 2)
            return;
        
        SpawnPowerup(destroyedBrick.transform.position);
    }

    public void SpawnPowerup(Vector2 spawnLocation)
    {
        int randomCollectable = GetWeightedCollectable();
        CollectableData collectableToSpawn = allCollectables[randomCollectable];
        
        Instantiate(collectableToSpawn.collectablePrefab, spawnLocation, Quaternion.identity);
        
        Debug.Log("Powerup Spawned!");
    }

    private int GetWeightedCollectable()
    {
        List<int> collectableWeights = new List<int>();
        int totalCollectableWeight = 0;
        
        foreach (CollectableData collectable in allCollectables) 
        {
            totalCollectableWeight += collectable.collectableWeight;
            collectableWeights.Add(collectable.collectableWeight);
        }


        int result = 0;
        int totalWeight = 0;
        
        int randomWeight = Random.Range(0, totalCollectableWeight);
        for (result = 0; result < collectableWeights.Count; result++) 
        {
            totalWeight += collectableWeights[result];
            
            if (totalWeight > randomWeight) 
                break;
        }

        return result;
    }
    

    private void RemovePowerups()
    {
        // When the player loses a life
        foreach (Powerup powerupComponent in activePowerups)
        {
            Destroy(powerupComponent);
        }
    }
}