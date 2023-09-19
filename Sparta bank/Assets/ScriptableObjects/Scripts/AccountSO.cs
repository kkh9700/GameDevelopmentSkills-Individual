using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Account", menuName = "SpartaBank/Account", order = 0)]
public class AccountSO : ScriptableObject
{
    [Header("Account Info")]
    public string id;
    public string pw;
    public string holder;
    public int cash;
    public int balance;
}
