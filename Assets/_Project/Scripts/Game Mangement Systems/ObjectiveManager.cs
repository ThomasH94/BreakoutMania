using System;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    //TODO: Create scriptable object Objectives
    //Check the current objective and inform anyone listening what it is
    //If the current objective becomes complete, alert the game manager so we can get a new objective or load back into the level select

    public GameObject objectivePanel;

    private void OnEnable()
    {
        EventManager.StartListening("Objective Complete",OnObjectiveComplete);
        objectivePanel.SetActive(false);
    }

    private void OnDisable()
    {
        EventManager.StopListening("Objective Complete",OnObjectiveComplete);
    }

    private void OnObjectiveComplete()
    {
        Debug.Log("OBJECTIVE COMPLETE");
        objectivePanel.SetActive(true);
        Time.timeScale = 0;    //TODO: Have the game manager handle this
    }
}
