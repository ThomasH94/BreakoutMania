using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private int lives;

    private void Start()
    {
        UpdateLives(0);
    }

    private void UpdateLives(int amount)
    {
        lives += amount;
        livesText.text = $"Lives: {lives.ToString()}";
    }

}
