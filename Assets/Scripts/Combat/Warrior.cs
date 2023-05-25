namespace Combat
{
    public class Warrior : AbstractHero
    {
        private void DoMeleeAttack(IDamageReceiver opponent)
        {
            opponent.ReceiveDamage(10);
        }

        public override void ReceiveDamage(int quantity)
        {
            
        }

        public override void DoAttack(IDamageReceiver opponent)
        {
            DoMeleeAttack(opponent);
        }
    }
}
