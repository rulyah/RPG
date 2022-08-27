using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu (fileName = "BowConfig", menuName = "Unit/Weapons/BowConfig")]

    public class BowConfig : Item
    {
        public int minDamage;
        public int maxDamage;
    }
}
