using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField]
    private InventorySO inventoryData;
    public Text numberCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item != null)
        {
            int reminder = inventoryData.AddItem(item.InventoryItem, item.Quantity);
            if (item.InventoryItem.name == "Coin")
            {
                numberCount.text = (int.Parse(numberCount.text) +  item.Quantity).ToString();
                item.DestroyItem();
            }
            else
            {
                if (reminder == 0)
                    item.DestroyItem();
                else
                    item.Quantity = reminder;
            }
            
        }

    }
}
