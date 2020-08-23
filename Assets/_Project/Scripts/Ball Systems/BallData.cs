using UnityEngine;

public enum BallType
{
    Main,    // Used to check which ball to track in the case of Mult-Ball
    Bouncy,
    Huge,
    Clone
}

[CreateAssetMenu(menuName = "Scriptable Objects/Ball Data", fileName = "New Ball Data")]
public class BallData : DataObject
{
    // Might replace this all with a custom inspector so we might not need this? Idk..
    [Header("Ball Info")]
    public BallType ballType;
    public float moveSpeed = 4.0f;

    [Header("Ball Graphics")]
    public TrailRenderer ballTrail;
}
