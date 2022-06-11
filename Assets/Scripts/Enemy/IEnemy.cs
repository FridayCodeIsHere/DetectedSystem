
namespace DetectorSystem
{
    public interface IEnemy
    {
        public string Name { get; }
        public int Health { get; }
        public int Damage { get; }
        public int Speed { get; }

        public void Attack();

        public void TakeDamage(int damageValue);
        public void Dead();
    }
}
