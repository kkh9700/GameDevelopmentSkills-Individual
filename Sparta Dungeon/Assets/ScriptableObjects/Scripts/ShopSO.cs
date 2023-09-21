using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopSO", menuName = "Sparta Dungeon/ShopSO", order = 2)]
public class ShopSO : ScriptableObject
{
    [Header("Shop Info")]
    public List<ItemSO> Items;

}