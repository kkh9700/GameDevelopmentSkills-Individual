using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Sparta Dungeon/ItemSO", order = 1)]
public class ItemSO : ScriptableObject
{
    public enum ItemType
    {
        Weapon, Armor, Shield, Boots
    }

    [Header("Item Info")]
    public Sprite icon;
    public string itemName;
    public ItemType type;
    public int statValue;
    public int price;
    public bool isEquip;
    public string description;
}