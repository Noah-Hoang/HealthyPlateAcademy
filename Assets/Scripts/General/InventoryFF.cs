using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryFF : MonoBehaviour
{
    // Start is called before the first frame update
    //Add items to inventory, unique items have _unique at the end
    //Check to see if its unique, if it is in Hashset then dont add to dictionary, if not, add to both Hashset and dictionary
    // If you get more than one unique, extra converted to $10
    public string inputString;
    public int inputInt;
    public Dictionary<string, int> inventoryDictionary;
    public HashSet<string> inventoryHashSet;
    public int money;
    void Start()
    {
        inventoryDictionary = new Dictionary<string, int>();
        inventoryHashSet = new HashSet<string>();
    }

    [ContextMenu("Add Item")]
    public void AddItemCM()
    {
        AddItem(inputString, inputInt);
    }

    public void AddItem(string itemName, int itemQuantity)
    {
        if (itemName.Contains("_unique"))
        {
            if (inventoryHashSet.Contains(itemName))
            {
                money += itemQuantity * 10;
                return;
            }
            else
            {
                inventoryHashSet.Add(itemName);
                inventoryDictionary.Add(itemName, 1);
                itemQuantity -= 1;
                money += itemQuantity * 10;
                return;
            }
        }
        else 
        {
            if (inventoryDictionary.ContainsKey(itemName))
            {
                inventoryDictionary[itemName] += itemQuantity;
            }
            else
            {
                inventoryDictionary.Add(itemName, itemQuantity);
            }
        }
    }

    [ContextMenu("Remove Item")]
    public void RemoveItemCM()
    {
        RemoveItem(inputString, inputInt);
    }

    public void RemoveItem(string itemName, int itemQuantity)
    {
        if (inventoryDictionary.ContainsKey(itemName) && inventoryDictionary[itemName] >= itemQuantity)
        {
            if (itemName.Contains("_unique"))
            {
                inventoryHashSet.Remove(itemName);
                inventoryDictionary.Remove(itemName);
            }
            else
            {
                if (itemQuantity == inventoryDictionary[itemName])
                {
                    inventoryDictionary.Remove(itemName);
                }
                else
                {
                    inventoryDictionary[itemName] -= itemQuantity;
                }
            }
        }
        else
        {
            Debug.Log("YOU DONT HAVE ENOUGH or THAT ITEM DOESN'T EXIST");
        }
    }

    [ContextMenu("Print Inventory")]
    public void PrintInventoryCM()
    {
        for (int i = 0; i < inventoryDictionary.Count; i++)
        {
            Debug.Log(inventoryDictionary.ElementAt(i).Key + ":" + inventoryDictionary.ElementAt(i).Value);
        }
    }
}
