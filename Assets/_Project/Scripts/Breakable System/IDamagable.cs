namespace BrickBreak.Breakable
{
    public interface IDamagable
    { 
        int Health { get; set; }
        void TakeDamage();
        void Die();
        void SpawnCollectable();
    }
}