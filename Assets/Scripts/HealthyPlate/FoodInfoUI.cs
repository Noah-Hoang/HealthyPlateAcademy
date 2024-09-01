using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodInfoUI : MonoBehaviour
{
    public GameObject grabbedFood;
    public TMP_Text ingredientNameDisplay;
    public TMP_Text ingredientTypeDisplay;
    public TMP_Text ingredientUnitDisplay;
    public TMP_Text ingredientCaloriesDisplay;
    // Start is called before the first frame update
    void Start()
    {
        StartDisplayInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDisplayInfo()
    {
        ingredientNameDisplay.text = grabbedFood.GetComponent<Ingredient>().ingredientSO.name;
        ingredientTypeDisplay.text = grabbedFood.GetComponent<Ingredient>().ingredientSO.type.ToString();
        ingredientUnitDisplay.text = grabbedFood.GetComponent<Ingredient>().ingredientSO.unit.ToString();
        ingredientCaloriesDisplay.text = grabbedFood.GetComponent<Ingredient>().ingredientSO.calories.ToString();

    }

    public void StopDisplayInfo()
    {

    }
}
