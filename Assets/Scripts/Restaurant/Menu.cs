using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string food;
    public string side;
    public string customization;
    public List<string> substitutionFoodsList;
    private int cookTime;
    public List<string> appetizersList;
    public List<string> entreeList;
    public List<string> drinksList;
    public List<string> dessertList;
    public List<string> kidsMenuList;

    public Menu(string foodTemp, string sideTemp = "Fries", string customizationTemp = "Nothing")
    {
        food = foodTemp;
        side = sideTemp;
        customization = customizationTemp;
    }

    public void ChooseSpeicals()
    {

    }

    public void GetItemsWithinPriceRange(float availableMoney)
    {

    }
}
