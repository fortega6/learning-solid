namespace Combat
{
    public class Wizard : AbstractHero
    {
        public override void ReceiveDamage(int quantity)
        {
            throw new System.NotImplementedException();
        }

        public override void DoAttack(IDamageReceiver opponent)
        {
            DoMagicAttack(opponent, MagicAttackType.Fire);
        }
        
        private void DoMagicAttack(IDamageReceiver opponent, MagicAttackType magicType)
        {
            //logic to select magic type
            opponent.ReceiveDamage(15);
        }

        private enum MagicAttackType
        {
            Fire,
            Ice,
            Water
        }
    }
}
