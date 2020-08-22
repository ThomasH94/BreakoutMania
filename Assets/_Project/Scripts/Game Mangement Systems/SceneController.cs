using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadAScene(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
