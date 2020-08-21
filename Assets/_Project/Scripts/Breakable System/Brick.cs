using System.Collections;
using BrickBreak.Breakable;
using BrickBreak.Utility;
using UnityEngine;

public class Brick : MonoBehaviour, IDamagable, ISetupable
{
    // Could have brick types that give you points, light up, and maybe stuff like glass that subtracts points

    public BrickManager currentBrickManager = null;
    
    public BrickData _brickData;
    public int Health { get; set; }
    
    public void Setup(ScriptableObject brickData)
    {
        if(brickData != null)
            brickData = _brickData;

        if (BrickManager.Instance != null)
            currentBrickManager = BrickManager.Instance;
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<BallController>())
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        Health--;
        if (Health <= 0)
        {
            // Destroy and add points -- play animation and sounds on hit
            if (ScoreController.Instance != null)
            {
                ScoreController.Instance.UpdateScore(_brickData.scoreAmount);
            }
            Destroy(gameObject);    // Currently, we are pooling this object, so we'll destroy it
        }
        else
        {
            // If we aren't dead, then start breaking  
            Debug.Log("Crumble");
        }
    }

    private void Crumble()
    {
        //TODO: Check the brick datas crumble sprites and update via Crumble Routine
        // This method will Crumble for bricks, leak light for lights, or match the current themes sprite breakage
    }

    private IEnumerator CrumbleRoutine()
    {
        // Slowly fade into the new crumble sprite and out of the old one
        yield return null;
    }
    
}
