using Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryCell : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Text _count;
        [SerializeField] private Button _button;
        public InventorySlot slot;

        private void OnButtonClick()
        {
            GameController.instance.player.Equip(slot.item);
        }
        public void Init(InventorySlot slot)
        {
            this.slot = slot;
            slot.onItemChange += SlotOnItemChange;
            Refresh();
            _button.onClick.AddListener(OnButtonClick);
        }


        private void SlotOnItemChange(Item item)
        {
            Refresh();
        }

        public void Refresh()
        {
            if (slot.item != null)
            {
                _image.gameObject.SetActive(true);
                _image.sprite = slot.item.icon;
            }
            else
            {
                _image.gameObject.SetActive(false);
            }
        }

    }
}
