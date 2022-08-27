using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory
{
    public class UnitInventory : MonoBehaviour
    {
        public List<InventorySlot> inventorySlots;
        
        
        

        public int GetFreeSlotsCount()
        {
            return inventorySlots.Count(t => t.item == null);
        }

        public InventorySlot FindSlot(Item item)
        {
            return inventorySlots.FirstOrDefault(t => t.item == item);
        }
    }
    
}
