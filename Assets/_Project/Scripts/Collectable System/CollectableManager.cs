using System.Collections.Generic;
using BrickBreak.Data;
using BrickBreak.Singletons;

public class CollectableManager : Singleton<CollectableManager>
{
    public List<PowerupData> allPowerups;
    public List<PowerupData> allPowerdowns;
}