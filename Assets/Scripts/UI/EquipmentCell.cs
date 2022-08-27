using Enums;
using Equip;
using Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EquipmentCell : MonoBehaviour
    {
        private EquipmentSlot _equipmentSlot;
        public EquipmentType equipmentType;
        [SerializeField] private Image _image;
        [SerializeField] private Text _count;
        [SerializeField] private Button _button;

        private void OnButtonClick()
        {
            GameController.instance.player.Disarm(equipmentType);
        }
        public void Init(EquipmentSlot slot)
        {
            slot.onItemChange += SlotOnItemChange;
            _equipmentSlot = slot;
            Refresh();
            _button.onClick.AddListener(OnButtonClick);
        }

        private void SlotOnItemChange(Item item)
        {
            Refresh();
        }

        private void Refresh()
        {
            if (_equipmentSlot.item == null)
            {
                _image.gameObject.SetActive(false);
                _count.gameObject.SetActive(false);
            }
            else
            {
                _image.gameObject.SetActive(true);
                _count.gameObject.SetActive(true);
                _image.sprite = _equipmentSlot.item.icon;
                _count.text = _equipmentSlot.item.count.ToString();
            }
        }
    }
}
