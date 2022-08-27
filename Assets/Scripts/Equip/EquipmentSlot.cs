using System;
using Enums;
using Inventory;
using UnityEngine;

namespace Equip
{
    [Serializable]
    public class EquipmentSlot 
    {
        public EquipmentType type;
        public Item item;
        public Transform transform;
        private GameObject _gameObject;

        public event Action<Item> onItemChange; 
        public void Insert(Item obj)
        {
            _gameObject = GameObject.Instantiate(obj.prefab, transform);
            _gameObject.transform.localPosition = Vector3.zero;
            _gameObject.transform.localRotation = Quaternion.identity;
            _gameObject.transform.localScale = Vector3.one;
            item = obj;
            onItemChange?.Invoke(item);
        }
        

        public void Clear()
        {
            if (item != null)
            {
                GameObject.Destroy(_gameObject);
                item = null;
                onItemChange?.Invoke(item);
            }
        }
    }
}
