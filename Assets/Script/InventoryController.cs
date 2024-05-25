using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    
    public class InventoryController : MonoBehaviour
    {

        public Health Health;

        public UIInventoryPage inventoryUI;

        public int inventorySize = 10;
        public InventorySO inventoryData;
        public List<InventoryItem> initialItems = new List<InventoryItem>();
        private void Start()
        {

            PrepareUI();
            PrepareInventoryData();
            
        }
        private void PrepareUI()
        {
            inventoryUI.InitializeInventoryUI(inventoryData.Size);

            inventoryUI.OnDescriptionRequested += HandleDescriptionRequested;
            inventoryUI.OnItemActionRequested += HandleItemActionRequested;

        }
        private void PrepareInventoryData()
        {
            inventoryData.Initialize();
            inventoryData.OnInventoryUpdated += UpdateInventoryUI;
            foreach (InventoryItem item in initialItems)
            {
                if (item.IsEmpty)
                    continue;
                inventoryData.AddItems(item);
            }
        }

        private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
        {
            inventoryUI.ResetAllItems();
            foreach (var item in inventoryState)
            {
                inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage,
                    item.Value.quantity);
            }
        }

        private void HandleItemActionRequested(int obj)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(obj);
            if (inventoryItem.IsEmpty)
            {
                inventoryUI.ResetSelection();
                return;
            }

          
            IItemAction item = inventoryItem.item as IItemAction;
            if(item != null)
            {
                item.PerformAction(gameObject);
            }

            IDestroyableItem destroyable = inventoryItem.item as IDestroyableItem;
            if (destroyable != null)
            {
                inventoryData.RemoveItem(obj, 1);
            }


        }

        private void HandleDescriptionRequested(int obj)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(obj);
            if (inventoryItem.IsEmpty)
            {
                inventoryUI.ResetSelection();
                return;
            }
            ItemSO Item = inventoryItem.item;
            inventoryUI.UpdateDescription(obj, Item.ItemImage, Item.name, Item.Description);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (inventoryUI.isActiveAndEnabled == false)
                {
                    inventoryUI.Show();
                    foreach (var item in inventoryData.GetCurrentInventoryState())
                    {
                        inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
                    }
                }
                else
                {
                    inventoryUI.Hide();
                }
            }

        }
    }

}


