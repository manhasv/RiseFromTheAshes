using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();
    private InventoryUIManager inventoryUIManager;

    void Start()
    {
        inventoryUIManager = FindObjectOfType<InventoryUIManager>();
    }

    public void AddItem(string name, int id, int qty, Sprite icon)
    {
        // check if item already exists
        InventoryItem item = inventory.Find(x => x.itemID == id);
        if (item != null)
        {
            item.quantity += qty;
        }
        else
        {
            inventory.Add(new InventoryItem(name, id, qty, icon));
        }
        inventoryUIManager.RefreshInventoryUI();
    }

    public void RemoveItem(int id, int qty)
    {
        // check if item exists
        InventoryItem item = inventory.Find(x => x.itemID == id);
        if (item != null)
        {
            item.quantity -= qty;
        }
        else
        {
            inventory.Remove(item);
        }
        inventoryUIManager.RefreshInventoryUI();
    }
}
