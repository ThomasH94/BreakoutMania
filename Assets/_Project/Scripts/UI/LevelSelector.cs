using BrickBreak.Data;
using BrickBreak.GameManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BrickBreak.Levels
{

    public class LevelSelector : MonoBehaviour
    {
        public TextMeshProUGUI levelNumber;
        public GameLevelData LevelData;
        public Button levelSelectButton;

        private void Start()
        {
            if (!LevelData.isUnlocked)
            {
                levelSelectButton.interactable = false;
            }
        }

        public void SetupSelector(int ID)
        {
            levelNumber.text = ID.ToString();
        }

        public void LoadLevel()
        {
            if (LevelData.isUnlocked)
            {
                SceneController.Instance.LoadGameplayScene(LevelData.name, LevelData);
            }
        }
    }
}