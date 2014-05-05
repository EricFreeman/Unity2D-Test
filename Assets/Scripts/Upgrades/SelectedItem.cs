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

    public void SelectItem(StoreItem item)
    {
        Name = item.Item.Name;
        Description = item.Item.Description;
        Price = item.Item.Price.ToString("c");
        GetComponentInChildren<BuyButton>().StoreItem = item;
    }

    void SetLabel(string name, string value)
    {
        transform.FindChild(name).GetComponentInChildren<UILabel>().text = value;
    }
}
