using System.Collections;
using BrickBreak.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameLevelData[] allLevelData;
    public GameLevelData currentLevelData; 
    
    [ContextMenu("Reload Scene")]
    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    
    public void LoadScene(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }
    
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public IEnumerator LoadSceneAdditiveRoutine(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad, LoadSceneMode.Additive);
        Scene sceneToLoad = SceneManager.GetSceneByName(levelToLoad);
        yield return loadOperation;
        SceneManager.SetActiveScene(sceneToLoad);
    }
    
    public IEnumerator LoadSceneAdditiveRoutine(int buildIndex)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
        Scene sceneToLoad = SceneManager.GetSceneAt(buildIndex);
        yield return loadOperation;
        SceneManager.SetActiveScene(sceneToLoad);
    }
}
