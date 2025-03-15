using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiters : Staff
{
    public List<Tables> assignedTables;
    

    public void Awake()
    {
        wage = 13.25f;
        workingHours = 8;
    }

    public void Update()
    {
        TakeMoney();
        CheckForCustomers();
    }

    public void CheckForCustomers()
    {
        for (int i = 0; i < assignedTables.Count; i++)
        {
            if (assignedTables[i].seatedCustomers != null && assignedTables[i].seatedCustomers.hasBeenAttendedTo == false
                && assignedTables[i].isDirty == false)
            {
                TakeOrder(assignedTables[i].seatedCustomers);
                Debug.Log("[Waiters.cs]Taking Order");
            }
        }
    }

    public void PromoteSpecials()
    {

    }

    public void TakeOrder(Customers customer)
    {
        Restaurant.instance.chefsList[0].PrepareFood(customer.PlaceOrder(), this);
        Debug.Log("[Waiters.cs]Order Taken");
    }

    public void ServeFood(Orders order)
    {
        order.customer.Eat(order);
        Debug.Log("[Waiters.cs]Food Served");
    }

    public void TakeMoney()
    {
        for (int i = 0; i < assignedTables.Count; i++)
        {
            if (assignedTables[i].seatedCustomers == null && assignedTables[i].isDirty == true)
            {
                Restaurant.instance.cashRegister.moneyInRegister += assignedTables[i].currentBill;
                currentMoney += assignedTables[i].tip;
                assignedTables[i].currentBill = 0.0f;
                assignedTables[i].tip = 0.0f;
                Debug.Log("[Waiters.cs] takes money and tip");
            }
        }    
    }
}
