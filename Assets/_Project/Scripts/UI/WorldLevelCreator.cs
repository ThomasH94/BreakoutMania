using BrickBreak.Data;
using UnityEngine;

namespace BrickBreak.Levels
{
    public class WorldLevelCreator : MonoBehaviour
    {
        public GameObject levelSelectorPrefab;
        public GameLevelData[] worldLevelData;
        public Transform spawnLocation;

        private void Start()
        {
            GenerateLevels();
        }

        private void GenerateLevels()
        {
            for (int i = 0; i < worldLevelData.Length; i++)
            {
                GameObject levelselectorToSpawn =
                    Instantiate(levelSelectorPrefab, spawnLocation.position, Quaternion.identity) as GameObject;
                levelselectorToSpawn.transform.SetParent(spawnLocation, false);
                LevelSelector levelSelector = levelselectorToSpawn.GetComponent<LevelSelector>();
                levelSelector.LevelData = worldLevelData[i];
                levelSelector.SetupSelector(i + 1);
            }
        }
    }
}