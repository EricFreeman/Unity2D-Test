using Assets.Scripts.Upgrades;
using UnityEngine;

public class ItemSelectButton : MonoBehaviour
{
    public Transform Gui;
    public Item Item;

    void OnClick()
    {
        var gui = Gui.GetComponent<InventoryMenu>();
        gui.Select(Item);
    }
}
