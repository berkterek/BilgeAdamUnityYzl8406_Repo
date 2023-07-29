namespace Platformer2D.Combats
{
    public class Damage : IDamage
    {
        readonly int _damageValue;

        public Damage(int damageValue)
        {
            _damageValue = damageValue;
        }

        public int DamageValue => _damageValue;
    }

    public interface IDamage
    {
        int DamageValue { get; }
    }
}