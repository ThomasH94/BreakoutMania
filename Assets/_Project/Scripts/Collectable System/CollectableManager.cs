using System.Collections.Generic;
using BrickBreak.Collectables;
using BrickBreak.Data;
using BrickBreak.Singletons;
using UnityEngine;

public class CollectableManager : Singleton<CollectableManager>
{
    public List<PowerupData> allPowerups;
    public List<PowerupData> allPowerdowns;
    
    private List<Powerup> activePowerups;

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