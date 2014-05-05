using Assets.Scripts.Upgrades;
using UnityEngine;

public class SelectedItem : MonoBehaviour
{
    string Name
    {
        set { SetLabel("Item Name", value); }
    }

    string Description
    {
        set { SetLabel("Item Description", value); }
    }

    string Price
    {
        set { SetLabel("Item Price", value); }
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void SelectItem(Item item)
    {
        Name = item.Name;
        Description = item.Description;
        Price = item.Price.ToString("c");
        GetComponentInChildren<BuyButton>().Item = item;
    }

    void SetLabel(string name, string value)
    {
        transform.FindChild(name).GetComponentInChildren<UILabel>().text = value;
    }
}
