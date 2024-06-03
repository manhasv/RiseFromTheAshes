using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject itemSlotPrefab;

    private InventoryManager inventoryManager;
    private List<GameObject> itemSlots = new List<GameObject>();
    private bool flip = false;

    void Start()
    {
        inventoryPanel.SetActive(false);
        inventoryManager = FindObjectOfType<InventoryManager>();
        RefreshInventoryUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            flip = !flip;
            inventoryPanel.SetActive(flip);
        }
    }

    public void RefreshInventoryUI()
    {
        foreach (GameObject slot in itemSlots)
        {
            if (slot != null) Destroy(slot);
        }
        itemSlots.Clear();

        foreach (InventoryItem item in inventoryManager.inventory)
        {
            GameObject itemSlot = Instantiate(itemSlotPrefab, inventoryPanel.transform);
            itemSlot.GetComponent<Image>().sprite = item.itemIcon;
            itemSlot.transform.Find("Quantity").GetComponent<Text>().text = item.quantity.ToString();
            itemSlots.Add(itemSlot);
        }
    }
}
