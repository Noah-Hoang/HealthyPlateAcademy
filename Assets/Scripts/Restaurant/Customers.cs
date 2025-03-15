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
        Debug.Log("[Customers.cs]Order Placed");
        return order;
    }

    public void Eat(Orders order)
    {
        Debug.Log("[Customers.cs]Customer Eating");
        Pay(10, 2);
    }

    public void Pay(float bill, float tip = 0)
    {
        currentTable.currentBill = bill;
        currentTable.tip = tip;
        currentTable.isDirty = true;
        currentTable.seatedCustomers = null;
        Debug.Log("[Customers.cs] pays " + bill + "" + "and leaves" + tip + "" + "as tip");
    }
}
