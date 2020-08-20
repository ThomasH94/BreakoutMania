namespace BrickBreak.Breakable
{
    public interface IDamagable
    { 
        int Health { get; set; }
        void TakeDamage();
    }
}