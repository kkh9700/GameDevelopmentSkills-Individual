using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using System;
public class TextUtil : MonoBehaviour
{
    public enum TextType
    {
        holder, cash, balance
    }

    public TextType type;
    private TMP_Text myText;

    private void Awake()
    {
        myText = GetComponent<TMP_Text>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case TextType.holder:
                myText.text = AccountManager.I.holder;
                break;
            case TextType.cash:
                myText.text = string.Format("{0:N0}", AccountManager.I.cash);
                break;
            case TextType.balance:
                myText.text = string.Format("{0:N0}", AccountManager.I.balance);
                break;
        }
    }
}
