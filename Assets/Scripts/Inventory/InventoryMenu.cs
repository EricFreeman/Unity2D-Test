using Assets.Models;
using Assets.Scripts.Upgrades;
using Assets.Services;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    private PlayerModel _currentPlayer;

    // Top Bar
    public Transform Grid;

    // Bottom Bar
    public Transform SelectedItemLabel;
    public Transform EquipButton;
    public Transform UnequipButton;

    void Start()
    {
        var manager = new XmlManager<PlayerModel>();
        _currentPlayer = manager.Load("savegame1.xml");

        ReloadInventory();
    }

    void ReloadInventory()
    {
        ClearInventoryGrid();
        foreach (var inv in _currentPlayer.Inventory)
        {
            var i = (GameObject)Instantiate(Resources.Load("Prefabs/GUI/InventoryItem"));
            i.transform.parent = Grid;
            i.transform.localScale = Vector3.one;

            i.GetComponentInChildren<UILabel>().text = inv.Name;
        }
        Grid.GetComponent<UIGrid>().repositionNow = true;
    }

    void ClearInventoryGrid()
    {
        foreach (Transform child in Grid.transform)
            Destroy(child.gameObject);
    }

    public void Equip(Item item)
    {
        _currentPlayer.Inventory.Remove(item);
        _currentPlayer.EquippedItems.Add(item);
    }

    public void Unequip(Item item)
    {
        _currentPlayer.EquippedItems.Remove(item);
        _currentPlayer.Inventory.Add(item);
    }
}
