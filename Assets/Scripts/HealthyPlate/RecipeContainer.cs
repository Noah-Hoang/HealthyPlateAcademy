using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecipeContainer : NetworkBehaviour
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

    public Transform spawnPoint;
    public RecipeSO currentRecipe;
    public List<IngredientRequirement> ingredientRequirements;
    public GameObject ingredientInsertedEffect;
    public GameObject completedRecipeEffect;
    public TMP_Text recipeNameDisplay;
    public TMP_Text recipeIngredientsDisplay;

    private void OnEnable()
    {
        HealthyPlateManager.Instance.onRecipeAssigned.AddListener(SetRecipe);
    }

    private void OnDisable()
    {
        HealthyPlateManager.Instance.onRecipeAssigned.RemoveListener(SetRecipe);
    }

    [ContextMenu("Set Recipe")]
    public void SetRecipe(RecipeSO recipeSO)
    {
        //allows for global access to recipeSO
        currentRecipe = recipeSO;  
        ingredientRequirements.Clear();
        //ingredientHolder is a reference to IngredientHolder that is in the RecipeSO
        //currentRecipe being a reference to the RecipeSO script
        //This foreach goes through all the ingredientHolders in RecipeSO and sets them to ingredientHolder
        for (int i = 0; i < currentRecipe.ingredientHolders.Count; i++)
        {
            //Sets IngredientRequirement to itself and allows for the variables to be changed
            IngredientRequirement newRequirement = new IngredientRequirement
            {
                //name is being set to the name of the ingredient by going through RecipeSO and then IngredientSO to get the ingredient name
                name = currentRecipe.ingredientHolders[i].ingredient.name,           // Set the name from the ingredient holder
                ingredientSO = currentRecipe.ingredientHolders[i].ingredient,
                //requiredQuantity is being set equal to the quantity from RecipeSO
                requiredQuantity = currentRecipe.ingredientHolders[i].quantity,     // Set the required quantity from the ingredient holder
                currentQuantity = 0,                              // Initialize current quantity to 0
                hasEnough = false                                 // Initially, set hasEnough to false
            };
            //Adds all the new additons from above to the ingredientRequirements list
            ingredientRequirements.Add(newRequirement);
        }

        recipeNameDisplay.text = recipeSO.ingredientName;
        recipeIngredientsDisplay.text = "";
        for (int j = 0; j < currentRecipe.ingredientHolders.Count; j++)
        {
            recipeIngredientsDisplay.text += "\u2022" + currentRecipe.ingredientHolders[j].ingredient.ingredientName + ": " + ingredientRequirements[j].currentQuantity + "/" + currentRecipe.ingredientHolders[j].quantity + "\n";
        }
    }

    //Add OnTriggerEnter
    //Check if the tag is ingredient
    //Get ingredient component to check if it is part of currentRecipe
    //If it is part of currentRecipe, destroy the game object and to the ingredient requirement for the specific ingredient and then if requirements are met, set hasEnough equal to true
    //Every time an ingredient is added, check to see if hasEnough is true for all ingredients
    //Once all ingredients are in, use HealthyPlayManager singleton to track when currentRecipe is completed
    public void OnTriggerEnter(Collider other)
    {
        //other.transform.root gets the parent game object
        if (other.transform.root.gameObject.tag == "Ingredient")
        {
            bool isRecipeRequirement = false;
            //Goes through all of the IngredientRequiremt in ingredientRequirements
            for (int i = 0; i < ingredientRequirements.Count; i++)
            {
                if (ingredientRequirements[i].hasEnough)
                {
                    return;
                }

                //Checks if what was thrown in is an ingredient from ingredientRequirements
                //Uses index to check with the list
                if (ingredientRequirements[i].ingredientSO == other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO)
                {
                    isRecipeRequirement = true;
                    ingredientRequirements[i].currentQuantity += 1;
                    recipeIngredientsDisplay.text = "";
                    for (int j = 0; j < currentRecipe.ingredientHolders.Count; j++)
                    {
                        recipeIngredientsDisplay.text += "\u2022" + currentRecipe.ingredientHolders[j].ingredient.ingredientName + ": " + ingredientRequirements[j].currentQuantity + "/" + currentRecipe.ingredientHolders[j].quantity + "\n";
                    }
                    //checks to see if the quantity requirement is met for the ingredient
                    if (ingredientRequirements[i].currentQuantity == ingredientRequirements[i].requiredQuantity)
                    {
                        ingredientRequirements[i].hasEnough = true;
                    }

                    Instantiate(ingredientInsertedEffect, other.transform.root.position, other.transform.root.rotation);
                    Destroy(other.transform.root.gameObject);                  
                }              
            }

            if (isRecipeRequirement == false) 
            {
                return;
            }

            //Returns out so that the onRecipeSucceded event isn't called unless every ingredient has the required amount
            for (int j = 0; j < ingredientRequirements.Count; j++)
            {
                //Checks if even one of the requirements isn't enough and if so, returns out
                //Once all ingredients have enough of the quantity, currentRecipe is successful
                if (!ingredientRequirements[j].hasEnough)
                {
                    return;
                }
            }
            Debug.Log("Recipe Successful");
            if (currentRecipe.completedRecipe != null)
            {
                Instantiate(completedRecipeEffect, spawnPoint.position, spawnPoint.rotation);
                Runner.Spawn(currentRecipe.completedRecipe, spawnPoint.position, spawnPoint.rotation);
            }
            HealthyPlateManager.Instance.onRecipeSucceded.Invoke();
        }
    }
}
