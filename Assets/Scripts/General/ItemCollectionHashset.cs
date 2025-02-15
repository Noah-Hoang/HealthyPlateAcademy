using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemCollectionHashset : MonoBehaviour
{
    // Start is called before the first frame update
    // Method called collectitem takes in string adds to hashset if item already exists already collected if not destroy
    //Method called show inventory shows all items 

    public string inputString;
    public HashSet<string> inventory;
    void Start()
    {
        inventory = new HashSet<string>();
    }

    [ContextMenu("Collect Item")]
    public void CollectItemCM()
    {
        CollectItem(inputString);
    }

    public void CollectItem(string collectedItem)
    {
        if (inventory.Contains(collectedItem))
        {
            Debug.Log("Already Collected");
            return;
        }
        else
        {
            inventory.Add(collectedItem);
            Debug.Log("Item Collected");
        }

    }

    [ContextMenu("Show Inventory")]
    public void ShowInventory()
    {
        foreach (string item in inventory)
        {
            Debug.Log(item);
        } 
    }
}
