using Assets.Managers;
using Assets.Models;
using Assets.Scripts.Upgrades;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    private PlayerModel _currentPlayer;
    public int MaxItems = 3;

    private int _equippedItemsCount
    {
        get { return _currentPlayer.EquippedItems.Count; }
    }

    // Top Bar
    public Transform Grid;

    // Center Bar
    public Transform EquippedGrid;

    // Bottom Bar
    public Transform SelectedItemLabel;
    public Transform EquipButton;
    public Transform UnequipButton;

    void Start()
    {
        _currentPlayer = PlayerManager.Load();
        ReloadInventory();
    }

    void ReloadInventory()
    {
        ClearInventoryGrid();

        foreach (var inv in _currentPlayer.Inventory)
            AddItemToGrid(inv, Grid);

        foreach (var inv in _currentPlayer.EquippedItems)
            AddItemToGrid(inv, EquippedGrid);
    }

    void ClearInventoryGrid()
    {
        foreach (Transform child in Grid.transform)
            NGUITools.Destroy(child.gameObject);

        Grid.GetComponent<UIGrid>().repositionNow = true;

        foreach (Transform child in EquippedGrid.transform)
            NGUITools.Destroy(child.gameObject);

        EquippedGrid.GetComponent<UIGrid>().repositionNow = true;
    }

    void AddItemToGrid(Item item, Transform grid)
    {
        var i = (GameObject)Instantiate(Resources.Load("Prefabs/GUI/InventoryItem"));
        i.transform.parent = grid;
        i.transform.localScale = Vector3.one;

        i.GetComponentInChildren<ItemSelectButton>().Item = item;
        i.GetComponentInChildren<ItemSelectButton>().Gui = transform;
        i.GetComponentInChildren<UILabel>().text = item.Name;
    }

    void EquipItemToGrid(Item item, bool equip)
    {
        var listToSearch = equip ? Grid.transform : EquippedGrid.transform;
        foreach (Transform child in listToSearch)
            if (child.GetComponentInChildren<ItemSelectButton>().Item == item)
                child.parent = equip ? EquippedGrid : Grid;

        Grid.GetComponent<UIGrid>().repositionNow = true;
        EquippedGrid.GetComponent<UIGrid>().repositionNow = true;
    }

    public void Select(Item item)
    {
        SelectedItemLabel.gameObject.SetActive(true);
        EquipButton.gameObject.SetActive(_currentPlayer.Inventory.Contains(item));
        UnequipButton.gameObject.SetActive(_currentPlayer.EquippedItems.Contains(item));
        SelectedItemLabel.GetComponent<UILabel>().text = item.Name;
        Grid.GetComponent<UIGrid>().repositionNow = true;
        EquippedGrid.GetComponent<UIGrid>().repositionNow = true;

        EquipButton.GetComponent<EquipItem>().Item = item;
        UnequipButton.GetComponent<UnequipItem>().Item = item;
    }

    public void Equip(Item item)
    {
        if (_equippedItemsCount < MaxItems)
        {
            _currentPlayer.Inventory.Remove(item);
            _currentPlayer.EquippedItems.Add(item);
            Select(item);
            EquipItemToGrid(item, true);

            SavePlayer();
        }
    }

    public void Unequip(Item item)
    {
        _currentPlayer.EquippedItems.Remove(item);
        _currentPlayer.Inventory.Add(item);
        Select(item);
        EquipItemToGrid(item, false);

        SavePlayer();
    }

    void SavePlayer()
    {
        PlayerManager.Save(_currentPlayer);
    }
}
