using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodInfoUI : MonoBehaviour
{
    //isLeft is a reference to which hand the canvas is on
    //isLeftHandHeld is a reference to which hand grabbed the object
    public bool isLeft;
    public Canvas canvas;
    public TMP_Text ingredientNameDisplay;
    public TMP_Text ingredientTypeDisplay;
    public TMP_Text ingredientUnitDisplay;
    public TMP_Text ingredientCaloriesDisplay;

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

    public void StartDisplayInfo(GameObject grabbedObject, bool isLeftHandHeld)
    {
        //Checks to see which hand and canvas is being used
        if (isLeftHandHeld && isLeft)
        {
            if (grabbedObject.transform.root.gameObject.tag == "Ingredient")
            {
                canvas.enabled = true;
                ingredientNameDisplay.text = "Ingredient: " + grabbedObject.GetComponent<Ingredient>().ingredientSO.ingredientName;
                ingredientTypeDisplay.text = "Type: " + grabbedObject.GetComponent<Ingredient>().ingredientSO.type.ToString();
                ingredientUnitDisplay.text = "Unit: " + grabbedObject.GetComponent<Ingredient>().ingredientSO.unit.ToString();
                ingredientCaloriesDisplay.text = "Calories: " + grabbedObject.GetComponent<Ingredient>().ingredientSO.calories.ToString();
            }
        }
        else if (!isLeftHandHeld && !isLeft)
        {
            if (grabbedObject.transform.root.gameObject.tag == "Ingredient")
            {
                canvas.enabled = true;
                ingredientNameDisplay.text = "Ingredient: " + grabbedObject.GetComponent<Ingredient>().ingredientSO.ingredientName;
                ingredientTypeDisplay.text = "Type: " + grabbedObject.GetComponent<Ingredient>().ingredientSO.type.ToString();
                ingredientUnitDisplay.text = "Unit: " + grabbedObject.GetComponent<Ingredient>().ingredientSO.unit.ToString();
                ingredientCaloriesDisplay.text = "Calories: " + grabbedObject.GetComponent<Ingredient>().ingredientSO.calories.ToString();
            }
        }
    }

    public void StopDisplayInfo(GameObject grabbedObject, bool isLeftHandHeld)
    {
        if (isLeftHandHeld && isLeft)
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
        else if (!isLeftHandHeld && !isLeft)
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
}
