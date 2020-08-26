using System;
using BrickBreak.GameManagement;
using BrickBreak.Singletons;

public class GameplayLevelManager : Singleton<GameplayLevelManager>
{
    protected override void Awake()
    {
        base.Awake();
    }
    
    private void OnEnable()
    {
        SceneController.OnLevelWasLoaded += UpdateCurrentLevelIndex;
    }

    private void UpdateCurrentLevelIndex()
    {
        
    }
    
}