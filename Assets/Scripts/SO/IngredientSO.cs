using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Cooking/Ingredient")]
public class IngredientSO : ScriptableObject
{
    public string ingredientName;  // Name of the ingredient (e.g., "Flour")
    public IngredientTypeEnum type;            // Type of ingredient (e.g., "Dry", "Liquid")
}