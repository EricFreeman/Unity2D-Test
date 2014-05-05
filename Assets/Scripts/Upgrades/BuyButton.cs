using Assets.Scripts.Upgrades;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public Transform UpgradeMenu;
    public Item Item;

    void OnClick()
    {
        UpgradeMenu.GetComponent<UpgradeMenu>().Buy(Item);
    }
}
