using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public int itemID;
    public int quantity;
    public Sprite itemIcon;

    // constructor
    public InventoryItem(string name, int id, int qty, Sprite icon)
    {
        itemName = name;
        itemID = id;
        quantity = qty;
        itemIcon = icon;
    }
}
