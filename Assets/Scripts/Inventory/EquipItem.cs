using Assets.Scripts.Upgrades;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    public Transform Gui;
    public Item Item;

    void OnClick()
    {
        Gui.GetComponent<InventoryMenu>().Equip(Item);
    }
}