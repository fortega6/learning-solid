namespace Combat
{
    public interface IAttacker
    {
        void DoAttack(IDamageReceiver opponent);
    }
}
