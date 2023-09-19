using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InputFieldUtil : MonoBehaviour
{
    public enum TextType
    {
        id, pw, money, pwConfirm, holder
    }
    public TextType type;
    private TMP_InputField myInputField;

    private void Awake()
    {
        myInputField = GetComponent<TMP_InputField>();
    }

    void Start()
    {
        switch (type)
        {
            case TextType.id:
                myInputField.onEndEdit.AddListener(delegate { SetIdentity(myInputField.text); });
                break;
            case TextType.pw:
                myInputField.onEndEdit.AddListener(delegate { setPassword(myInputField.text); });
                break;
            case TextType.pwConfirm:
                myInputField.onEndEdit.AddListener(delegate { setPwConfirm(myInputField.text); });
                break;
            case TextType.holder:
                myInputField.onEndEdit.AddListener(delegate { setHolder(myInputField.text); });
                break;
            case TextType.money:
                myInputField.onEndEdit.AddListener(delegate { SetInput(myInputField.text); });
                break;
        }
    }


    void SetIdentity(string str)
    {
        BankManager.I.id = str;
    }

    void setPassword(string str)
    {
        BankManager.I.pw = str;
    }

    void setPwConfirm(string str)
    {
        BankManager.I.pwConfirm = str;
    }

    void setHolder(string str)
    {
        BankManager.I.holder = str;
    }
    void SetInput(string str)
    {
        Int32.TryParse(str, out BankManager.I.input);
    }
}
