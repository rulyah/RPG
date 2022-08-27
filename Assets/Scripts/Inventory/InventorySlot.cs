using System;

namespace Inventory
{
    [Serializable]
    public class InventorySlot
    {
        public Item item;

        //public Item item => _item;
        //[SerializeField] private Item _item;
        

        public event Action<Item> onItemChange;

        public void Insert(Item item)
        {
            this.item = item;
            onItemChange?.Invoke(item);
        }

    }
}