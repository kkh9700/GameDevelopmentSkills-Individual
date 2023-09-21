using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemSlotUI : MonoBehaviour
{
    [SerializeField]
    private Image Icon;
    [SerializeField]
    private TMP_Text Name;
    [SerializeField]
    private TMP_Text Description;
    [SerializeField]
    private Image StatIcon;
    [SerializeField]
    private TMP_Text StatValue;
    [SerializeField]
    private TMP_Text Price;

    private ItemSO item;
    private Shop shop;

    public int index;

    public void Set(Shop _shop, ItemSO _item)
    {
        shop = _shop;
        item = _item;

        Set();
    }

    private void Set()
    {
        Icon.sprite = item.icon;
        Name.text = item.itemName;
        Description.text = item.description;
        switch (item.type)
        {
            case ItemSO.ItemType.Weapon:
                StatIcon.sprite = Resources.Load<Sprite>("Icon/Attack");
                StatIcon.color = new Color32(255, 100, 100, 255);
                StatValue.color = new Color32(255, 100, 100, 255);
                break;
            case ItemSO.ItemType.Shield:
                StatIcon.sprite = Resources.Load<Sprite>("Icon/Defense");
                StatIcon.color = new Color32(100, 150, 255, 255);
                StatValue.color = new Color32(100, 150, 255, 255);
                break;
            case ItemSO.ItemType.Armor:
                StatIcon.sprite = Resources.Load<Sprite>("Icon/Hp");
                StatIcon.color = new Color32(20, 220, 140, 255);
                StatValue.color = new Color32(20, 220, 140, 255);
                break;
            case ItemSO.ItemType.Boots:
                StatIcon.sprite = Resources.Load<Sprite>("Icon/Critical");
                StatIcon.color = new Color32(255, 120, 0, 255);
                StatValue.color = new Color32(255, 120, 0, 255);
                break;
        }

        StatValue.text = "+" + item.statValue;
        Price.text = string.Format("{0:#,###}", item.price);
    }

    public void OnButtonClick()
    {
        bool isPurchase;

        shop.BuyItem(index, out isPurchase);

        if (isPurchase)
        {
            gameObject.SetActive(false);
        }
    }
}
