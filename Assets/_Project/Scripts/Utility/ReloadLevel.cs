using BrickBreak.GameManagement;
using UnityEngine;

public class ReloadLevel : MonoBehaviour
{
    public void ReloadCurrentLevel()
    {
        SceneController.Instance.ReloadScene();
    }
}