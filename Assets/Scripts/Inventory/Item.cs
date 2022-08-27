using Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class Item : ScriptableObject
    {
        public EquipmentType equipmentType;
        public GameObject prefab;
        public WeaponsType weaponsType;
        public string name;
        public Sprite icon;
        public int count;
    }
}
