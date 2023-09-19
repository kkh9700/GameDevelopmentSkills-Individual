using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountManager : MonoBehaviour
{
    public static AccountManager I;
    [HideInInspector]
    public string holder;
    [HideInInspector]
    public int cash { get; private set; }
    [HideInInspector]
    public int balance { get; private set; }
    [HideInInspector]
    public string id;

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

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(id + "_cash", cash);
        PlayerPrefs.SetInt(id + "_balance", balance);
    }

    public void SetAccount(string _id)
    {
        id = _id;

        holder = PlayerPrefs.GetString(id + "_holder");
        cash = PlayerPrefs.GetInt(id + "_cash");
        balance = PlayerPrefs.GetInt(id + "_balance");
    }

    public void SetCash(int money)
    {
        cash += money;
    }

    public void SetBalance(int money)
    {
        balance += money;
    }
}
