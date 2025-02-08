using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySystemDict : MonoBehaviour
{
    public string itemName;
    public int itemQuantity;
    public Dictionary<string, int> inventoryDictionary;
    // Method that is called passes in string and quantity adds to dictionary
    // Method that passes in string and quantity and removes from dictionary
    //Method prints whats in dictionary
    // Catch errors with second method removing more than we have

    private void Start()
    {
        inventoryDictionary = new Dictionary<string, int>();
    }
    [ContextMenu("Add Item")]
    public void ContextAddItem()
    {
        AddItem(itemName, itemQuantity);
    }

    [ContextMenu("Remove Item")]
    public void ContextRemoveItem()
    {
        RemoveItem(itemName, itemQuantity);
    }

    public void AddItem(string itemName, int itemQuantity)
    {
        if (itemQuantity <= 0)
        {
            return;
        }
        if (inventoryDictionary.ContainsKey(itemName))
        {
            inventoryDictionary[itemName] = inventoryDictionary[itemName] + itemQuantity;
        }
        else
        {
            inventoryDictionary.Add(itemName, itemQuantity);
        }
    }

    public void RemoveItem(string itemName, int itemQuantity)
    {
        if (inventoryDictionary.ContainsKey(itemName) && (itemQuantity > 0))
        {
            if (itemQuantity > inventoryDictionary[itemName])
            {
                Debug.Log("Removing more than you have");
                return;
            }
            else
            {
                inventoryDictionary[itemName] = inventoryDictionary[itemName] - itemQuantity;
                if (inventoryDictionary[itemName] == 0)
                {
                    inventoryDictionary.Remove(itemName);
                }
            }
        }
    }

    [ContextMenu("Print Inventory")]
    public void PrintInventory()
    {
        for (int i = 0;  i < inventoryDictionary.Count; i++)
        {
            Debug.Log(inventoryDictionary.ElementAt(i).Key + ":" + inventoryDictionary.ElementAt(i).Value);
        }
    }
}
