using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodInfoUI : MonoBehaviour
{
    public TMP_Text ingredientNameDisplay;
    public TMP_Text ingredientTypeDisplay;
    public TMP_Text ingredientUnitDisplay;
    public TMP_Text ingredientCaloriesDisplay;
    public Canvas canvas;
    // Start is called before the first frame update

    public void OnEnable()
    {
        NetworkedGrab.OnObjectGrabbed.AddListener(StartDisplayInfo);
        NetworkedGrab.OnObjectReleased.AddListener(StopDisplayInfo);
    }

    public void OnDisable()
    {
        NetworkedGrab.OnObjectGrabbed.RemoveListener(StartDisplayInfo);
        NetworkedGrab.OnObjectReleased.RemoveListener(StopDisplayInfo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDisplayInfo(GameObject grabbedFood)
    {
        canvas.enabled = true;
        ingredientNameDisplay.text = "Ingredient:" + grabbedFood.GetComponent<Ingredient>().ingredientSO.name;
        ingredientTypeDisplay.text = "Type:" + grabbedFood.GetComponent<Ingredient>().ingredientSO.type.ToString();
        ingredientUnitDisplay.text = "Unit:" + grabbedFood.GetComponent<Ingredient>().ingredientSO.unit.ToString();
        ingredientCaloriesDisplay.text = "Calories" + grabbedFood.GetComponent<Ingredient>().ingredientSO.calories.ToString();

    }

    public void StopDisplayInfo(GameObject grabbedObject)
    {
        canvas.enabled = false;
        ingredientNameDisplay.text = "";
        ingredientTypeDisplay.text = "";
        ingredientUnitDisplay.text = "";
        ingredientCaloriesDisplay.text = "";
    }
}
