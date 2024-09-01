using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeDisplay : MonoBehaviour
{
    public TMP_Text ingredientName;
    public TMP_Text ingredientType;
    public TMP_Text ingredientUnit;
    public TMP_Text ingredientMeasurement;
    public TMP_Text ingredientCalories;
    public RecipeSO pbjRecipe;

    // Start is called before the first frame update
    void Start()
    {
        ingredientName.text = pbjRecipe.ingredientHolders[0].ingredient.ingredientName;
        ingredientType.text = pbjRecipe.ingredientHolders[0].quantity.ToString();
        ingredientUnit.text = pbjRecipe.ingredientHolders[0].ingredient.unit.ToString();
        ingredientMeasurement.text = pbjRecipe.ingredientHolders[0].unitMeasurement.ToString();
        ingredientCalories.text = pbjRecipe.ingredientHolders[0].ingredient.calories.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
