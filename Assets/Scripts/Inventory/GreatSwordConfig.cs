using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu (fileName = "GreatSwordConfig", menuName = "Unit/Weapons/GreatSwordConfig")]
    public class GreatSwordConfig : Item
    {
        public int minDamage;
        public int maxDamage;
    }
}
