using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct IngredientHolder 
{
    public IngredientSO ingredient;
    public int quantity;
    public float unitMeasurement;
}

[CreateAssetMenu(fileName = "New Recipe", menuName = "Cooking/Recipe")]
public class RecipeSO : ScriptableObject
{
    public GameObject completedRecipe;
    public List<IngredientHolder> ingredientHolders;
}