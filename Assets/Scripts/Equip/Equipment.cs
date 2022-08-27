using System.Collections.Generic;
using Enums;
using Inventory;
using UnityEngine;

namespace Equip
{
    public class Equipment : MonoBehaviour
    {
        public List<EquipmentSlot> slots;

        public void Equip(Item item)
        {
            var itemSlot = slots.Find(n => n.type == item.equipmentType);
            itemSlot.Insert(item);      
        }

        public void DeEquip(EquipmentSlot slot)
        {
            slot.Clear();
        }

        public void DeEquip(EquipmentType type)
        {
            var itemSlot = slots.Find(n => n.type == type);
            DeEquip(itemSlot);
        }

        public EquipmentSlot GetSlotByType(EquipmentType type)
        {
            for (var i = 0; i < slots.Count; i++)
            {
                if (slots[i].type == type)
                {
                    return slots[i];
                }
            }
            return null;
        }
    
    
    
    
    }
}
