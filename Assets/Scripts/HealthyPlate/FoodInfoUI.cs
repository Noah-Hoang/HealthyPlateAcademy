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
        NetworkedGrab.OnObjectGrabbedStatic.AddListener(StartDisplayInfo);
        NetworkedGrab.OnObjectReleasedStatic.AddListener(StopDisplayInfo);
    }

    public void OnDisable()
    {
        NetworkedGrab.OnObjectGrabbedStatic.RemoveListener(StartDisplayInfo);
        NetworkedGrab.OnObjectReleasedStatic.RemoveListener(StopDisplayInfo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDisplayInfo(GameObject grabbedObject)
    {
        if (grabbedObject.transform.root.gameObject.tag == "Ingredient")
        {
            canvas.enabled = true;
            ingredientNameDisplay.text = "Ingredient:" + grabbedObject.GetComponent<Ingredient>().ingredientSO.name;
            ingredientTypeDisplay.text = "Type:" + grabbedObject.GetComponent<Ingredient>().ingredientSO.type.ToString();
            ingredientUnitDisplay.text = "Unit:" + grabbedObject.GetComponent<Ingredient>().ingredientSO.unit.ToString();
            ingredientCaloriesDisplay.text = "Calories" + grabbedObject.GetComponent<Ingredient>().ingredientSO.calories.ToString();
        }
    }

    public void StopDisplayInfo(GameObject grabbedObject)
    {
        if (grabbedObject.transform.root.gameObject.tag == "Ingredient")
        {
            canvas.enabled = false;
            ingredientNameDisplay.text = "";
            ingredientTypeDisplay.text = "";
            ingredientUnitDisplay.text = "";
            ingredientCaloriesDisplay.text = "";
        }
    }
}
