using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour
{
    public int partySize;
    public float availableMoney;
    public Tables currentTable;
    public bool hasBeenAttendedTo;
    public Orders servedFood;

    public Orders PlaceOrder(Orders order = null)
    {
        if (order = null)
        {
            order = new Orders();
        }
        order.customer = this;
        Debug.Log("Order Placed");
        return order;
    }

    public void Eat(Orders order)
    {
        Debug.Log("Customer Eating");
    }
}
