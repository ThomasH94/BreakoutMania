using System.Collections.Generic;
using BrickBreak.Breakable;
using BrickBreak.Data.Collectibles;
using BrickBreak.EventManagement;
using BrickBreak.Singletons;
using UnityEngine;

namespace BrickBreak.Collectibles
{

    public class CollectibleManager : Singleton<CollectibleManager>
    {
        public List<CollectibleData> allCollectibles;

        public List<Powerup> activePowerups;

        private void OnEnable()
        {
            Brick.OnAnyBrickDied += OnAnyBrickDestroyedHandler;
            Powerup.OnAnyPowerupTriggered += AddPowerup;
            EventManager.StartListening("Lose Life", RemovePowerups);
        }

        private void OnDisable()
        {
            Brick.OnAnyBrickDied -= OnAnyBrickDestroyedHandler;
            Powerup.OnAnyPowerupTriggered -= AddPowerup;
            EventManager.StopListening("Lose Life", RemovePowerups);
        }

        private void OnAnyBrickDestroyedHandler(Brick destroyedBrick)
        {
            // Should a collectible be spawned?
            int spawnCollectible = Random.Range(0, 3);
            if (spawnCollectible < 2)
                return;

            SpawnPowerup(destroyedBrick.transform.position);
        }

        public void SpawnPowerup(Vector2 spawnLocation)
        {
            int randomCollectible = GetWeightedCollectible();
            CollectibleData collectibleToSpawn = allCollectibles[randomCollectible];

            Instantiate(collectibleToSpawn.collectiblePrefab, spawnLocation, Quaternion.identity);

            Debug.Log("Powerup Spawned!");
        }

        private int GetWeightedCollectible()
        {
            List<int> collectibleWeights = new List<int>();
            int totalCollectibleWeight = 0;

            foreach (CollectibleData collectible in allCollectibles)
            {
                totalCollectibleWeight += collectible.collectibleWeight;
                collectibleWeights.Add(collectible.collectibleWeight);
            }

            int result = 0;
            int totalWeight = 0;

            int randomWeight = Random.Range(0, totalCollectibleWeight);
            for (result = 0; result < collectibleWeights.Count; result++)
            {
                totalWeight += collectibleWeights[result];

                if (totalWeight > randomWeight)
                    break;
            }

            return result;
        }

        private void AddPowerup(Powerup powerup)
        {
            if (!activePowerups.Contains(powerup))
                activePowerups.Add(powerup);
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
}