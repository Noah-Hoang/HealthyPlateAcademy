using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecpieContainer : MonoBehaviour
{
    [System.Serializable]
    public struct IngredientRequirement
    {
        public string name;
        public int requiredQuantity;
        public int currentQuantity;
        public bool hasEnough;
    }

    public RecipeSO recipe;
    public List<IngredientRequirement> ingredientRequirements;

    public void Start()
    {
        foreach (IngredientHolder ingredientHolder in recipe.ingredientHolders)
        {
            IngredientRequirement newRequirement = new IngredientRequirement
            {
                name = ingredientHolder.ingredient.name,           // Set the name from the ingredient holder
                requiredQuantity = ingredientHolder.quantity,     // Set the required quantity from the ingredient holder
                currentQuantity = 0,                              // Initialize current quantity to 0
                hasEnough = false                                 // Initially, set hasEnough to false
            };

            ingredientRequirements.Add(newRequirement);
        }
    }
}
