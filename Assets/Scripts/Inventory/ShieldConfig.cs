using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu (fileName = "ShieldConfig", menuName = "Unit/Weapons/ShieldConfig")]
    public class ShieldConfig : Item
    {
        public int armor;
        public int damage;
    }
}
