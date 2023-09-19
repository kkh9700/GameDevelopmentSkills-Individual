using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public enum AlterType
    {
        SignUp, General
    }
    public static UIManager I;

    [SerializeField]
    private GameObject BankAlter;
    [SerializeField]
    private GameObject SignUpAlter;
    [SerializeField]
    private List<GameObject> list;
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

    public void OnAlter(string message, AlterType type)
    {
        switch (type)
        {
            case AlterType.SignUp:
                SignUpAlter.GetComponentInChildren<TMP_Text>().text = message;
                break;
            case AlterType.General:
                BankAlter.GetComponentInChildren<TMP_Text>().text = message;
                BankAlter.SetActive(true);
                break;
        }
    }

    public void SetActiveFalse(int index)
    {
        list[index].SetActive(false);
    }

    public void SetActivetrue(int index)
    {
        list[index].SetActive(true);
    }
}
