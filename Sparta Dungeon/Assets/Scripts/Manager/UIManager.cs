using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager I;
    [SerializeField]
    private GameObject EquipWindow;
    [SerializeField]
    private GameObject PurchaseWindow;

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

    public void OnEquipWindow(InvetoryItemSlotUI slotUI)
    {
        EquipWindow.GetComponent<EquipUI>().SetData(slotUI);
        EquipWindow.SetActive(true);
    }

    public void OnPurchaseWindow(bool isPurchase)
    {
        PurchaseWindow.GetComponent<PurchaseUI>().SetText(isPurchase);
        PurchaseWindow.SetActive(true);
    }
}