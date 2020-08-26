using UnityEngine;
using System.IO;
using BrickBreak.Singletons;

namespace BrickBreak.GameManagement
{

    /// <summary>
    /// Reference the video you used this from
    /// </summary>
    public class SaveGameManager : Singleton<SaveGameManager>
    {
        public GameData.GameData playerData;

        public string saveGameFolder = "/SaveGameData/";
        public string saveFileName = "GameData.sav";


        // Start is called before the first frame update
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
            LoadGameDataWithJSON();
        }

        [ContextMenu("Save Game")]
        public void SaveGameDataWithJSON()
        {
            // Convert our Scriptable Object Game Data - to a JSON string 
            string jsonString = JsonUtility.ToJson(playerData.SaveData);
            // Find our save destination
            string dataPath = Application.persistentDataPath + saveGameFolder;
            Debug.Log(dataPath);

            // Check if there is a directory before saving
            if (!Directory.Exists(dataPath))
            {
                Debug.Log("Directory doesn't exist...creating now..");
                Directory.CreateDirectory(dataPath);
            }

            // Set our save data, write to the data path, then close the stream writer
            StreamWriter streamWriter = new StreamWriter(dataPath + saveFileName);
            streamWriter.Write(jsonString);
            streamWriter.Close();

            Debug.Log("Save successful");
        }

        [ContextMenu("Load Game")]
        public void LoadGameDataWithJSON()
        {
            // Get our full data path, which includes the folder the save is in, and the
            // save file type suffix
            string fullDataPath = Application.persistentDataPath + saveGameFolder + saveFileName;

            if (File.Exists(fullDataPath))
            {
                // Get all of the text in the save file
                string jsonString = File.ReadAllText(fullDataPath);

                Debug.Log("Found file directory: " + fullDataPath);

                JsonUtility.FromJsonOverwrite(jsonString, playerData.SaveData);
            }
            else
            {
                Debug.Log("ERROR! Could not load save game data! Save file does not exist!");
            }
        }
    }
}