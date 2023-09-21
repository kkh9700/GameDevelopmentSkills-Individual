using UnityEngine;
using System.Linq;

public class Shop : MonoBehaviour
{
    private ShopItemSlotUI[] uiSlots;

    [SerializeField]
    private ShopSO shop;

    private ItemSO[] items;
    public Transform Slots;

    private void Start()
    {
        Init();

        uiSlots = new ShopItemSlotUI[items.Length];

        for (int i = 0; i < uiSlots.Length; i++)
        {
            GameObject ShopItemSlot = Instantiate(Resources.Load<GameObject>("Prefabs/ShopItemSlot"), Slots);
            uiSlots[i] = ShopItemSlot.GetComponent<ShopItemSlotUI>();
            uiSlots[i].Set(this, items[i]);

            uiSlots[i].index = i;
        }
    }

    private void Init()
    {
        items = new ItemSO[shop.Items.Count];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = shop.Items[i];
        }
    }


    public void BuyItem(int index, out bool isPurchase)
    {
        isPurchase = GameManager.I.BuyItem(items[index]);

        if (isPurchase)
        {
            shop.Items.Remove(items[index]);
        }

        UIManager.I.OnPurchaseWindow(isPurchase);
    }
}