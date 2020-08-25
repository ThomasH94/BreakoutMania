using System;
using System.Collections;
using System.Collections.Generic;
using BrickBreak.Ball;
using BrickBreak.Data;
using BrickBreak.Singletons;
using UnityEngine;

public class GameplayManager : Singleton<GameplayManager>
{
    public SceneController sceneController;
    public static event Action OnLevelCompleted;
    
    private void LoadGameplay()
    {
        //Setup the level here
        //Setup the paddle here - spawn it, have a global access to it, and change it's graphics based on the level
    }

    // Let's try using ONE method for complete
    // After completing a level, always call the OnLevelCompleted event, and change the results screen
    // behavior based on the level results - win/lose
    [ContextMenu("Level Complete")]
    public void LevelCompleted(bool success)
    {
        StartCoroutine(LevelCompleteRoutine(success));


        // Case - win

        // Unlock the next level if it's not unlocked...
        // if(currentscene += 1 != null, if .isUnlocked = false) isUnlocked = true;
        // Trigger a save of some sort - score/highscore, all of the unlocked levels, and w.e else

        // Case - lose
        
    }

    private IEnumerator LevelCompleteRoutine(bool success)
    {
        yield return sceneController.LoadSceneAdditiveRoutine("Results");
        OnLevelCompleted?.Invoke();

        if (success)
        {
            EventManager.TriggerEvent("Level Success");   
        }
        else
        {
            EventManager.TriggerEvent("Level Failed");
        }
    }

    // TODO: Instead of objectives, reward a high score based on this formula:
    // Current Score + Lives someMultiplier + TimeRemaining someMultiplier + somePowerUpMultiplier + friendlyBlocks;
    // GameManager can be notified OnLevelComplete from BrickManager and calculate score from there
    // Removes the need for an Objective Manager and Objectives
}
