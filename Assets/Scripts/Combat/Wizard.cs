using UnityEngine;

namespace Combat
{
    public class Wizard : AbstractHero
    {
        private float _baseDamage;

        private float _fireDamageMultiplier;
        private float _fireAttackProbability;

        private float _iceDamageMultiplier;
        private float _iceAttackProbability;

        private float _waterDamageMultiplier;
        private float _waterAttackProbability;

        public Wizard(float baseDamage, float fireDamageMultiplier, float fireAttackProbability,
                      float iceDamageMultiplier, float iceAttackProbability, float waterDamageMultiplier,
                      float waterAttackProbability)
        {
            _baseDamage = baseDamage;
            _fireDamageMultiplier = fireDamageMultiplier;
            _fireAttackProbability = fireAttackProbability;
            _iceDamageMultiplier = iceDamageMultiplier;
            _iceAttackProbability = iceAttackProbability;
            _waterDamageMultiplier = waterDamageMultiplier;
            _waterAttackProbability = waterAttackProbability;
        }

        public override void DoAttack(IDamageReceiver opponent)
        {
            var magicAttackType = GetMagicAttackType();
            if (magicAttackType == MagicAttackType.Fire)
            {
                DoMagicAttack(opponent, magicAttackType, _fireDamageMultiplier);
                DoMagicAttack(opponent, magicAttackType, _fireDamageMultiplier);
            }

            if (magicAttackType == MagicAttackType.Ice)
            {
                return;
            }

            if (magicAttackType == MagicAttackType.Water)
            {
                DoMagicAttack(opponent, magicAttackType, _waterDamageMultiplier);
            }
        }

        private static MagicAttackType GetMagicAttackType()
        {
            return MagicAttackType.Fire;
        }

        private void DoMagicAttack(IDamageReceiver opponent, MagicAttackType magicType, float damageMultiplier)
        {
            //logic to select magic type

            // DoSomething1();
            // DoSomething2();
            // DoSomething3();
            // DoSomething4();
            // DoSomething5();

            var damage = Mathf.RoundToInt(_baseDamage * damageMultiplier);
            opponent.ReceiveDamage(quantity: damage);
        }


        public override void ReceiveDamage(int quantity)
        {
            // TODO: update health
            throw new System.NotImplementedException();
        }


        private enum MagicAttackType
        {
            Fire,
            Ice,
            Water,
        }
    }
}
