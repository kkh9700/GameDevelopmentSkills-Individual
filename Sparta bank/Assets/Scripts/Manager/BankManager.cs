using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BankManager : MonoBehaviour
{
    public static BankManager I;
    [HideInInspector]
    public int input;
    [HideInInspector]
    public string id;
    [HideInInspector]
    public string holder;
    [HideInInspector]
    public string pw;
    [HideInInspector]
    public string pwConfirm;

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
        // PlayerPrefs.DeleteAll();
        Init();
    }

    private void Init()
    {
        input = 0;
        id = "";
        pw = "";
        pwConfirm = "";
        holder = "";
    }

    public void Deposit()
    {
        Deposit(input);
    }
    public void Deposit(int money)
    {
        if (AccountManager.I.cash < money)
        {
            UIManager.I.OnAlter("잔액이 부족합니다.", UIManager.AlterType.General);
            return;
        }

        AccountManager.I.SetCash(-money);
        AccountManager.I.SetBalance(money);
    }

    public void widthDraw()
    {
        widthDraw(input);
    }

    public void widthDraw(int money)
    {
        if (AccountManager.I.balance < money)
        {
            UIManager.I.OnAlter("잔액이 부족합니다.", UIManager.AlterType.General);
            return;
        }

        AccountManager.I.SetBalance(-money);
        AccountManager.I.SetCash(money);
    }

    public void Remittance()
    {
        if ("".Equals(id) || input == 0)
        {
            UIManager.I.OnAlter("입력 정보를 확인해주세요.", UIManager.AlterType.General);
        }

        if (AccountManager.I.balance < input)
        {
            UIManager.I.OnAlter("잔액이 부족합니다.", UIManager.AlterType.General);
            return;
        }

        if (!PlayerPrefs.HasKey(id))
        {
            UIManager.I.OnAlter("대상이 없습니다.", UIManager.AlterType.General);
            return;
        }

        AccountManager.I.SetBalance(-input);
        PlayerPrefs.SetInt(id + "_balance", PlayerPrefs.GetInt(id + "_balance") + input);
    }

    public void Login()
    {
        if (!PlayerPrefs.HasKey(id) || "".Equals(id))
        {
            UIManager.I.OnAlter("존재하지 않는 ID입니다.", UIManager.AlterType.General);
            return;
        }

        string _pw = PlayerPrefs.GetString(id);

        if (!_pw.Equals(pw) || "".Equals(pw))
        {
            UIManager.I.OnAlter("비밀번호가 틀렸습니다.", UIManager.AlterType.General);
            return;
        }

        AccountManager.I.SetAccount(id);

        UIManager.I.SetActiveFalse(0);
        UIManager.I.SetActivetrue(1);
        UIManager.I.SetActivetrue(2);

        Init();
    }


    public void SignUp(GameObject gameObject)
    {
        Regex regex = new Regex("^[a-zA-Z0-9]{3,10}$");
        if (!regex.IsMatch(id) || PlayerPrefs.HasKey(id))
        {
            UIManager.I.OnAlter("ID를 확인해주세요.", UIManager.AlterType.SignUp);
            return;
        }

        regex = new Regex("^[a-zA-Z0-9]{5,15}$");

        if (!regex.IsMatch(pw) || !pw.Equals(pwConfirm))
        {
            UIManager.I.OnAlter("비밀번호를 확인해주세요.", UIManager.AlterType.SignUp);
            return;
        }

        regex = new Regex("^[가-힣]{2,5}$");

        if (!regex.IsMatch(holder))
        {
            UIManager.I.OnAlter("이름을 확인해주세요.", UIManager.AlterType.SignUp);
            return;
        }

        PlayerPrefs.SetString(id, pw);
        PlayerPrefs.SetString(id + "_holder", holder);
        PlayerPrefs.SetInt(id + "_cash", 100000);
        PlayerPrefs.SetInt(id + "_balance", 50000);

        gameObject.SetActive(false);

        Init();
    }
}
