using BrickBreak.Breakable;

public class PowerupBrick : Brick
{
    //TODO: Create an array of power ups and pull one at the start, then spawn it in DestroyBrick
    
    protected override void DestroyBrick()
    {
        // Instantiate a powerup
        base.DestroyBrick();
    }
}
