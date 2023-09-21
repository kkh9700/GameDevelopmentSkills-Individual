using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class EquipUI : MonoBehaviour
{
    [Header("Item")]
    [SerializeField]
    public Image itemImage;
    [SerializeField]
    public TMP_Text itemName;
    [SerializeField]
    public TMP_Text itemDescription;
    [SerializeField]
    public Image statImage;
    [SerializeField]
    public Image statBackground;
    [SerializeField]
    public TMP_Text statName;
    [SerializeField]
    public TMP_Text statValue;
    [SerializeField]
    public TMP_Text alter;

    private InvetoryItemSlotUI slotUI;

    public void SetData(InvetoryItemSlotUI _slotUI)
    {
        slotUI = _slotUI;
        ItemSO item = slotUI.GetItem();

        itemImage.sprite = item.icon;
        itemName.text = item.itemName;
        itemDescription.text = item.description;
        switch (item.type)
        {
            case ItemSO.ItemType.Weapon:
                statImage.sprite = Resources.Load<Sprite>("Icon/Attack");
                statName.text = "Attack";
                break;
            case ItemSO.ItemType.Shield:
                statImage.sprite = Resources.Load<Sprite>("Icon/Defense");
                statName.text = "Defense";
                break;
            case ItemSO.ItemType.Armor:
                statImage.sprite = Resources.Load<Sprite>("Icon/Hp");
                statName.text = "Hp";
                break;
            case ItemSO.ItemType.Boots:
                statImage.sprite = Resources.Load<Sprite>("Icon/Defense");
                statName.text = "Critical";
                break;
        }
        statValue.text = item.statValue.ToString();

        if (item.isEquip)
        {
            alter.text = "장착 해제 하시겠습니까??";
        }
        else
        {
            alter.text = "장착 하시겠습니까??";
        }
    }

    public void OnConfirm()
    {
        slotUI.ItemEquip = !slotUI.ItemEquip;

        GameManager.I.GetPlayer().Equip(slotUI.GetItem());

    }
}
