using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemName;
    public int itemID;
    public int quantity;
    public Sprite itemIcon;

    private InventoryItem item;
    
    void Start()
    {
        item = new InventoryItem(itemName, itemID, quantity, itemIcon);
    }
}
