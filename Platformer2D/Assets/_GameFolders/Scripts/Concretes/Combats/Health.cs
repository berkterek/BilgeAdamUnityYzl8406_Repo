namespace Platformer2D.Combats
{
    public class Health : IHealth
    {
        readonly int _maxHealth;
        int _currentHealth;
        public event System.Action<int, int> OnCurrentHealthValueChanged;
        public int CurrentHealth => _currentHealth;

        public Health(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(IDamage damage)
        {
            _currentHealth -= damage.DamageValue;
            OnCurrentHealthValueChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }

    public interface IHealth
    {
        public void TakeDamage(IDamage damage);
        event System.Action<int, int> OnCurrentHealthValueChanged;
        int CurrentHealth { get; }
    }
}