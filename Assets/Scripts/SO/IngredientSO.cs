using UnityEngine;

//There can only be either a scriptable object or a struct, not both
//This script is a scriptable object
//Line below adds a new menu option for creation
[CreateAssetMenu(fileName = "New Ingredient", menuName = "Cooking/Ingredient")]
public class IngredientSO : ScriptableObject
{
    [Header("General")]
    public string ingredientName;  // Name of the ingredient (e.g., "Flour")
    public IngredientTypeEnum type;            // Type of ingredient (e.g., "Dry", "Liquid")
    public IngredientUnitEnum unit;
    public int calories;
    
    [Header("Cut")]
    public GameObject cutPrefab;
    public bool destroyAfterCut;
    [Header("fried")]
    public GameObject friedPrefab;
    public bool destroyAfterFried;
    [Header("Seared")]
    public GameObject searedPrefab;
    public bool destroyAfterSeared;
}