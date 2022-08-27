using Inventory;
using UnityEngine;

namespace UI
{
    public class InventoryController : WindowController
    {
        [SerializeField] private UnitInventory _unitInventory;
        [SerializeField] private GameObject _cellPrefab;
        [SerializeField] private Transform parent;

        public override void Init()
        {
            for (var i = 0; i < _unitInventory.inventorySlots.Count; i++)
            {
                var cell = Instantiate(_cellPrefab, parent);
                var inventoryCell = cell.GetComponent<InventoryCell>();
                inventoryCell.Init(_unitInventory.inventorySlots[i]);
            }
            base.Init();
        }
    }
}