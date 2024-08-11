using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeDisplay : MonoBehaviour
{
    public TMPro.TextMeshPro ingredientName;
    public TMPro.TextMeshPro ingredientType;
    public TMPro.TextMeshPro ingredientUnit;
    public TMPro.TextMeshPro ingredientMeasurement;
    public TMPro.TextMeshPro ingredientCalories;
    public RecipeSO pbjRecipe;

    // Start is called before the first frame update
    void Start()
    {
        ingredientName.text = pbjRecipe.ingredients[0].ingredient.ingredientName;
        ingredientType.text = pbjRecipe.ingredients[0].quantity.ToString();
        ingredientUnit.text = pbjRecipe.ingredients[0].unit.ToString();
        ingredientMeasurement.text = pbjRecipe.ingredients[0].unitMeasurement.ToString();
        ingredientCalories.text = pbjRecipe.ingredients[0].calories.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
