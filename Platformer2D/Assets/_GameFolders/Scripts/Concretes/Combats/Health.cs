namespace Platformer2D.Combats
{
    public class Health : IHealth
    {
        readonly int _maxHealth;
        int _currentHealth;

        public Health(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(IDamage damage)
        {
            _currentHealth -= damage.DamageValue;
        }
    }

    public interface IHealth
    {
        public void TakeDamage(IDamage damage);
    }
}