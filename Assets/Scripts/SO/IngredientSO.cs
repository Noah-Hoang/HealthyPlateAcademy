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
    public int protein;
    public Sprite referenceImage;
    
    [Header("Cut")]
    public GameObject cutPrefab;
    public bool destroyAfterCut;

    [Header("Fried")]
    public GameObject friedPrefab;
    public bool destroyAfterFried;
    public float timeUntilFried;

    [Header("Seared")]
    public GameObject searedPrefab;
    public bool destroyAfterSeared;
    public float timeUntilSeared;

    [Header("Boil")]
    public GameObject boiledPrefab;
    public bool destroyAfterBoiled;
    public float timeUntilBoiled;

    [Header("Oven Cooked")]
    public GameObject ovenCookedPrefab;
    public bool destroyAfterOvenCooked;
    public float timeUntilOvenCooked;
}