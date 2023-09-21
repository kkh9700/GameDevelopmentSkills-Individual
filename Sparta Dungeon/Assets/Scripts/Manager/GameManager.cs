using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    [SerializeField]
    private PlayerSO player;

    public int maxInventory = 120;

    private void Awake()
    {
        if (I == null)
        {
            I = this;
        }

        if (I != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

    }

    public PlayerSO GetPlayer() { return player; }

    public bool BuyItem(ItemSO item)
    {
        if (player.Gold < item.price)
            return false;

        player.Inventory.Add(item);
        player.Gold -= item.price;

        return true;
    }
}
