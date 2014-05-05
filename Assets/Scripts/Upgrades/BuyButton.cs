using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public Transform UpgradeMenu;
    public StoreItem StoreItem;

    void OnClick()
    {
        UpgradeMenu.GetComponent<UpgradeMenu>().Buy(StoreItem);
    }
}
