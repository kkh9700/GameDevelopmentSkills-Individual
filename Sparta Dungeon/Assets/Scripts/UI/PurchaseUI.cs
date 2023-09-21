using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PurchaseUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;


    public void SetText(bool isPurchase)
    {
        if (isPurchase)
        {
            text.text = "구매하였습니다.";
        }
        else
        {
            text.text = "골드가 부족합니다.";
        }
    }
}
