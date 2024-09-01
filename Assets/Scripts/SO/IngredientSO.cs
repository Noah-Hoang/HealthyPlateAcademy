using UnityEngine;

//There can only be either a scriptable object or a struct, not both
//This script is a scriptable object
//Line below adds a new menu option for creation
[CreateAssetMenu(fileName = "New Ingredient", menuName = "Cooking/Ingredient")]
public class IngredientSO : ScriptableObject
{
    public string ingredientName;  // Name of the ingredient (e.g., "Flour")
    public IngredientTypeEnum type;            // Type of ingredient (e.g., "Dry", "Liquid")
    public IngredientUnitEnum unit;
    public int calories;

    public GameObject cutPrefab;
    public GameObject friedPrefab;
    public GameObject searedPrefab;
}