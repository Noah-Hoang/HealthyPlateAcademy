using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Host : Staff
{
    public void Awake()
    {
        wage = 15.0f;
        workingHours = 8;
    }

    public void Update()
    {
        FindAvailableTable();
    }

    public void FindAvailableTable()
    {
        if (Restaurant.instance.customersQueue.Count > 0)
        {
            Customers customer = Restaurant.instance.customersQueue.Dequeue();  
            SeatCustomers(customer);
            Debug.Log("[Host.cs]Finding available table");
        }
        else
        {
            return;
        }
    }

    public void SeatCustomers(Customers customer)
    {
        for (int i = 0; i < Restaurant.instance.tablesList.Count; i++)
        {
            if ((Restaurant.instance.tablesList[i].isDirty == false) && (Restaurant.instance.tablesList[i].amountOfSeats >= customer.partySize) 
                && (Restaurant.instance.tablesList[i].seatedCustomers == null))
            {
                customer.currentTable = Restaurant.instance.tablesList[i];
                Restaurant.instance.tablesList[i].seatedCustomers = customer;
                Debug.Log("[Host.cs]Customer seated at table");
            }
               
        }
    }
}
