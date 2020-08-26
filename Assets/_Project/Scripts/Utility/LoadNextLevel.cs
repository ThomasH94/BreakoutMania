using BrickBreak.GameManagement;
using UnityEngine;

namespace BrickBreak.Utility
{
    public class LoadNextLevel : MonoBehaviour
    {
        public void LoadTheNextLevel()
        {
            SceneController.Instance.LoadNextLevel();
        }
    }
}