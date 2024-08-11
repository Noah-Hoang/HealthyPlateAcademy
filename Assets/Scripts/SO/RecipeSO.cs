using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct IngredientHolder 
{
    public IngredientSO ingredient;
    public int quantity;
    public IngredientUnitEnum unit;
    public float unitMeasurement;
    public float calories;
}

[CreateAssetMenu(fileName = "New Recipe", menuName = "Cooking/Recipe")]
public class RecipeSO : ScriptableObject
{
    public List<IngredientHolder> ingredientHolders;
}