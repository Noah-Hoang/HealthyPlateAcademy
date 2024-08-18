using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecpieContainer : MonoBehaviour
{
    [System.Serializable]
    public class IngredientRequirement
    {
        public string name;
        public IngredientSO ingredientSO;
        public int requiredQuantity;
        public int currentQuantity;
        public bool hasEnough;
    }

    public RecipeSO recipe;
    public List<IngredientRequirement> ingredientRequirements;

    public void Start()
    {
        //ingredientHolder is a reference to IngredientHolder that is in the RecipeSO
        //recipe being a reference to the RecipeSO script
        //This foreach goes through all the ingredientHolders in RecipeSO and sets them to ingredientHolder
        foreach (IngredientHolder ingredientHolder in recipe.ingredientHolders)
        {
            //Sets IngredientRequirement to itself and allows for the variables to be changed
            IngredientRequirement newRequirement = new IngredientRequirement
            {
                //name is being set to the name of the ingredient by going through RecipeSO and then IngredientSO to get the ingredient name
                name = ingredientHolder.ingredient.name,           // Set the name from the ingredient holder
                ingredientSO = ingredientHolder.ingredient,
                //requiredQuantity is being set equal to the quantity from RecipeSO
                requiredQuantity = ingredientHolder.quantity,     // Set the required quantity from the ingredient holder
                currentQuantity = 0,                              // Initialize current quantity to 0
                hasEnough = false                                 // Initially, set hasEnough to false
            };
            //Adds all the new additons from above to the ingredientRequirements list
            ingredientRequirements.Add(newRequirement);
        }
    }
    //Add OnTriggerEnter
    //Check if the tag is ingredient
    //Get ingredient component to check if it is part of recipe
    //If it is part of recipe, destroy the game object and to the ingredient requirement for the specific ingredient and then if requirements are met, set hasEnough equal to true
    //Every time an ingredient is added, check to see if hasEnough is true for all ingredients
    //Once all ingredients are in, use HealthyPlayManager singleton to track when recipe is completed

    public void OnTriggerEnter(Collider other)
    {
        //other.transform.root gets the parent game object
        if (other.transform.root.gameObject.tag == "Ingredient")
        {
            //Goes through all of the IngredientRequiremt in ingredientRequirements
            for (int i = 0; i < ingredientRequirements.Count; i++)
            {
                //Checks if what was thrown in is an ingredient from ingredientRequirements
                //Uses index to check with the list
                if (ingredientRequirements[i].ingredientSO == other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO)
                {
                    ingredientRequirements[i].currentQuantity += 1;
                    //checks to see if the quantity requirement is met for the ingredient
                    if (ingredientRequirements[i].currentQuantity == ingredientRequirements[i].requiredQuantity)
                    {
                        ingredientRequirements[i].hasEnough = true;
                    }
                    
                    Destroy(other.transform.root.gameObject);
                }
            }

            for (int j = 0; j < ingredientRequirements.Count; j++)
            {
                //Checks if even one of the requirements isn't enough and if so, returns out
                //Once all ingredients have enough of the quantity, recipe is successful
                if (!ingredientRequirements[j].hasEnough)
                {
                    return;
                }
            }
            Debug.Log("Recipe Successful");
            HealthyPlateManager.Instance.onRecipeSucceded.Invoke();
        }
    }
}
