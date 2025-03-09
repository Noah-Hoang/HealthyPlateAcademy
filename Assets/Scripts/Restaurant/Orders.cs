using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orders : MonoBehaviour
{
    public string food;
    public string side;
    public string customization;
    public Customers customer;
    public Orders(string tempFood = "Burger", string tempSide = "Fries", string tempCustomization = "None")
    {
        food = tempFood;
        side = tempSide;
        customization = tempCustomization;
    }
}
