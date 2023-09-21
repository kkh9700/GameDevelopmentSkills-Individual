using UnityEngine;
using UnityEngine.UI;

public class InvetoryItemSlotUI : MonoBehaviour
{
    [SerializeField]
    private GameObject EquipMark;
    [SerializeField]
    private Image icon;
    private ItemSO curItem;

    public int index;
    private bool isEquip = false;
    private Inventory inventory;

    public ItemSO GetItem() { return curItem; }

    public bool ItemEquip
    {
        get
        {
            return isEquip;
        }
        set
        {
            isEquip = value;

            if (value)
            {
                EquipMark.SetActive(true);
            }
            else
            {
                EquipMark.SetActive(false);
            }

            if (curItem != null)
            {
                curItem.isEquip = value;
            }
        }
    }

    public void Set(Inventory _inventory, ItemSO slot)
    {
        inventory = _inventory;
        curItem = slot;
        icon.sprite = slot.icon;
        icon.gameObject.SetActive(true);
        ItemEquip = slot.isEquip;
    }

    public void Clear()
    {
        curItem = null;
        ItemEquip = false;
        icon.gameObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        if (curItem != null)
            inventory.SelectItem(index);
    }


}