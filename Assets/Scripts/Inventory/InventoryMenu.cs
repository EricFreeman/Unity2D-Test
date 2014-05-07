using Assets.Models;
using Assets.Scripts.Upgrades;
using Assets.Services;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    private PlayerModel _currentPlayer;

    void Start()
    {
        var manager = new XmlManager<PlayerModel>();
        _currentPlayer = manager.Load("savegame1.xml");
    }

    public void Equip(Item item)
    {
        _currentPlayer.Inventory.Remove(item);
        _currentPlayer.EquippedItems.Add(item);
    }

    public void UnEquip(Item item)
    {
        _currentPlayer.EquippedItems.Remove(item);
        _currentPlayer.Inventory.Add(item);
    }
}
