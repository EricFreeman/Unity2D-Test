using Assets.Scripts.Upgrades;
using UnityEngine;

public class SelectedItem : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void SelectItem(Item item)
    {
        SetLabel("Item Name", item.Name); 
        SetLabel("Item Description", item.Description);
        SetLabel("Item Price", item.Price.ToString("c")); 
        GetComponentInChildren<BuyButton>().Item = item;
    }

    void SetLabel(string name, string value)
    {
        transform.FindChild(name).GetComponentInChildren<UILabel>().text = value;
    }
}
