using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public InvetoryItemSlotUI[] uiSlots;
    public ItemSO[] items;
    public Transform Slots;

    private void Start()
    {
        uiSlots = new InvetoryItemSlotUI[GameManager.I.maxInventory];

        for (int i = 0; i < uiSlots.Length; i++)
        {
            GameObject InvetoryItemSlot = Instantiate(Resources.Load<GameObject>("Prefabs/InventoryItemSlot"), Slots);

            uiSlots[i] = InvetoryItemSlot.GetComponent<InvetoryItemSlotUI>();
        }

        items = new ItemSO[uiSlots.Length];

        for (int i = 0; i < items.Length; i++)
        {
            if (i < GameManager.I.GetPlayer().Inventory.Count)
            {
                items[i] = GameManager.I.GetPlayer().Inventory[i];
                uiSlots[i].Set(this, items[i]);
            }
            else
            {
                items[i] = new ItemSO();
                uiSlots[i].Clear();
            }
            uiSlots[i].index = i;
        }
    }

    public void SelectItem(int index)
    {
        UIManager.I.OnEquipWindow(uiSlots[index]);
    }
}
