namespace Combat
{
    public abstract class AbstractHero : IDamageReceiver, IAttacker
    {
        public abstract void AddDamage(int           damage);

        public abstract void DoAttack(IDamageReceiver opponent);
    }
}
