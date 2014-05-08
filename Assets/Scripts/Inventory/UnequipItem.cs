using Assets.Scripts.Upgrades;
using UnityEngine;

public class UnequipItem : MonoBehaviour
{
    public Transform Gui;
    public Item Item;

    void OnClick()
    {
        Gui.GetComponent<InventoryMenu>().Unequip(Item);
    }
}