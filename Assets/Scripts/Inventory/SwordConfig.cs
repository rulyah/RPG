using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu (fileName = "SwordConfig", menuName = "Unit/Weapons/SwordConfig")]

    public class SwordConfig : Item
    {
        public int minDamage;
        public int maxDamage;
    }
}
