using System.Collections.Generic;
using Equip;
using UnityEngine;

namespace UI
{
    public class EquipmentController : MonoBehaviour
    {
        [SerializeField] private Equipment _equipment;
        public List<EquipmentCell> cells;

        public void Init()
        {
            for (var i = 0; i < _equipment.slots.Count; i++)
            {
                var cell = cells.Find(n => n.equipmentType == _equipment.slots[i].type);
                cell.Init(_equipment.slots[i]);
            }
        }
    }
}
