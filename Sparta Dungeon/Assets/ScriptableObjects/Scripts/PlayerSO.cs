using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Sparta Dungeon/PlayerSO", order = 0)]
public class PlayerSO : ScriptableObject
{
    public string Name;
    public string Description;
    public int Gold;

    [Header("Stat Info")]
    public int Level;
    public int Exp;
    public int Hp;
    public int Attack;
    public int Defense;
    public int Critical;

    [Header("Inventory Info")]
    public List<ItemSO> Inventory;


    public void Equip(ItemSO item)
    {
        switch (item.type)
        {
            case ItemSO.ItemType.Weapon:
                Attack += item.statValue * (item.isEquip ? 1 : -1);
                break;
            case ItemSO.ItemType.Shield:
                Defense += item.statValue * (item.isEquip ? 1 : -1);
                break;
            case ItemSO.ItemType.Armor:
                Hp += item.statValue * (item.isEquip ? 1 : -1);
                break;
            case ItemSO.ItemType.Boots:
                Critical += item.statValue * (item.isEquip ? 1 : -1);
                break;
        }
    }
}