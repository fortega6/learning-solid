namespace Combat
{
    public class Archer : AbstractHero
    {
        private void DoRangeAttack(IDamageReceiver opponent)
        {
            opponent.ReceiveDamage(10);
        }

        public override void ReceiveDamage(int quantity)
        {
        }

        public override void DoAttack(IDamageReceiver opponent)
        {
            DoRangeAttack(opponent);
        }
    }
}
