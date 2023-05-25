namespace Combat
{
    public abstract class AbstractHero : IAttacker, IDamageReceiver
    {
        public abstract void ReceiveDamage(int           quantity);

        public abstract void DoAttack(IDamageReceiver opponent);
    }
}
