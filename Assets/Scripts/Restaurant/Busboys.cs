using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Busboys : Staff
{
    public void Awake()
    {
        wage = 10.50f;
        workingHours = 8;
    }

    public void Update()
    {
        
    }

    public void ClearTables()
    {
        for (int i = 0; i < Restaurant.instance.tablesList.Count; i++)
        {
            if (Restaurant.instance.tablesList[i].isDirty == true && Restaurant.instance.tablesList[i].currentBill == 0.0f)
            {
                Restaurant.instance.tablesList[i].isDirty = false;
                Debug.Log("[Busboy.cs] cleaned table");
            }
        }
    }
}
