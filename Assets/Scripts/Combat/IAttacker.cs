using UnityEditor;
using UnityEngine;

namespace Combat
{
    public interface IAttacker
    {
        void DoAttack(IDamageReceiver opponent);
    }
}