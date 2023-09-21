using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextUtil : MonoBehaviour
{
    public enum TextType
    {
        PlayerName, PlayerDesc, PlayerLevel, PlayerExp, PlayerAttack, PlayerDefense, PlayerHP, PlayerCritical, PlayerMoney, SliderExp, Inventory
    }

    public TextType type;
    private TMP_Text myText;
    private Slider mySlider;

    private void Awake()
    {
        if (type == TextType.SliderExp)
            mySlider = GetComponent<Slider>();
        else
            myText = GetComponent<TMP_Text>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case TextType.PlayerName:
                myText.text = GameManager.I.GetPlayer().Name;
                break;
            case TextType.PlayerDesc:
                myText.text = GameManager.I.GetPlayer().Description;
                break;
            case TextType.PlayerLevel:
                myText.text = GameManager.I.GetPlayer().Level.ToString();
                break;
            case TextType.PlayerExp:
                myText.text = GameManager.I.GetPlayer().Exp.ToString() + " / " + (GameManager.I.GetPlayer().Level + 2).ToString();
                break;
            case TextType.PlayerAttack:
                myText.text = GameManager.I.GetPlayer().Attack.ToString();
                break;
            case TextType.PlayerDefense:
                myText.text = GameManager.I.GetPlayer().Defense.ToString();
                break;
            case TextType.PlayerHP:
                myText.text = GameManager.I.GetPlayer().Hp.ToString();
                break;
            case TextType.PlayerCritical:
                myText.text = GameManager.I.GetPlayer().Critical.ToString();
                break;
            case TextType.PlayerMoney:
                myText.text = GameManager.I.GetPlayer().Gold.ToString();
                break;
            case TextType.SliderExp:
                mySlider.value = ((float)GameManager.I.GetPlayer().Exp) / (GameManager.I.GetPlayer().Level + 2);
                break;
            case TextType.Inventory:
                myText.text = "Inventory    <color=\"yellow\">" + GameManager.I.GetPlayer().Inventory.Count + "</color> / " + GameManager.I.maxInventory;
                break;
        }
    }
}
