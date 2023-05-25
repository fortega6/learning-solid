
using UnityEngine;

namespace Combat
{
    public class Rogue : AbstractHero
    {
        private void DoMeleeAttack(IDamageReceiver opponent)
        {
            opponent.ReceiveDamage(10);
        }

        private void DoRangeAttack(IDamageReceiver opponent)
        {
            opponent.ReceiveDamage(10);
        }

        public override void ReceiveDamage(int quantity)
        {
            
        }

        public override void DoAttack(IDamageReceiver opponent)
        {
            if (Random.Range(1, 100) > 50)
            {
                DoMeleeAttack(opponent);
            }
            else
            {
                DoRangeAttack(opponent);
            }
        }
    }
}
