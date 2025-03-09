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
        CheckForCustomers();
    }

    public void CheckForCustomers()
    {
        for (int i = 0; i < assignedTables.Count; i++)
        {
            if (assignedTables[i].seatedCustomers != null && assignedTables[i].seatedCustomers.hasBeenAttendedTo == false)
            {
                TakeOrder(assignedTables[i].seatedCustomers);
                Debug.Log("Taking Order");
            }
        }
    }

    public void PromoteSpecials()
    {

    }

    public void TakeOrder(Customers customer)
    {
        Restaurant.instance.chefsList[0].PrepareFood(customer.PlaceOrder(), this);
        Debug.Log("Order Taken");
    }

    public void ServeFood(Orders order)
    {
        order.customer.Eat(order);
        Debug.Log("Food Served");
    }
}
