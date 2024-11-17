using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RecipeContainer : NetworkBehaviour, IPlayerJoined
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
    public TMP_Text recipeNameDisplay;
    public TMP_Text recipeIngredientsDisplay;
    public Image referenceImage;

    public UnityEvent onRecipeCompleted;

    private void OnEnable()
    {
        HealthyPlateManager.Instance.onRecipeAssigned.AddListener(SetRecipe);
        HealthyPlateManager.Instance.onRecipeSucceded.AddListener(ClearBoard);
        HealthyPlateManager.Instance.onRecipeFailed.AddListener(ClearBoard);
    }

    private void OnDisable()
    {
        HealthyPlateManager.Instance.onRecipeAssigned.RemoveListener(SetRecipe);
        HealthyPlateManager.Instance.onRecipeSucceded.RemoveListener(ClearBoard);
        HealthyPlateManager.Instance.onRecipeFailed.RemoveListener(ClearBoard);
    }

    [ContextMenu("Set Recipe")]
    public void SetRecipe(RecipeSO recipeSO)
    {
        //Allows for global access to recipeSO
        currentRecipe = recipeSO;  
        //Wipes ingredientRequirements
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
        referenceImage.sprite = recipeSO.referenceImage;
        for (int j = 0; j < ingredientRequirements.Count; j++)
        {
            recipeIngredientsDisplay.text += "\u2022" + ingredientRequirements[j].ingredientSO.ingredientName + ": " + ingredientRequirements[j].currentQuantity + "/" + currentRecipe.ingredientHolders[j].quantity + "\n";
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
            if (!Object.HasStateAuthority)
            {
                return;
            }
            Debug.Log("Ingredient detected");
            bool isRecipeRequirement = false;

            //Goes through all of the IngredientRequiremt in ingredientRequirements
            for (int i = 0; i < ingredientRequirements.Count; i++)
            {
                if (ingredientRequirements[i].hasEnough)
                {
                    continue;
                }

                //Checks if what was thrown in is an ingredient from ingredientRequirements
                //Uses index to check with the list
                if (ingredientRequirements[i].ingredientSO == other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO)
                {
                    Debug.Log("Ingredient needed in recipe");
                    isRecipeRequirement = true;
                    ingredientRequirements[i].currentQuantity += 1;                    

                    //Changing ingredient display
                    recipeIngredientsDisplay.text = "";
                    for (int j = 0; j < ingredientRequirements.Count; j++)
                    {
                        recipeIngredientsDisplay.text += "\u2022" + ingredientRequirements[j].ingredientSO.ingredientName + ": " + ingredientRequirements[j].currentQuantity + "/" + currentRecipe.ingredientHolders[j].quantity + "\n";
                    }

                    //checks to see if the quantity requirement is met for the ingredient
                    if (ingredientRequirements[i].currentQuantity == ingredientRequirements[i].requiredQuantity)
                    {
                        ingredientRequirements[i].hasEnough = true;
                    }

                    Debug.Log("Adding ingredient to recipe");
                    Runner.Spawn(ingredientInsertedEffect, other.transform.root.position, other.transform.root.rotation);
                    Runner.Despawn(other.transform.root.GetComponent<NetworkObject>());                  
                }

                if (Object.HasStateAuthority)
                {
                    RecipeProgressRPC(recipeIngredientsDisplay.text);
                }
            }

            if (isRecipeRequirement == false)
            {
                return;
            }

            //Returns out so that the onRecipeSucceded event isn't called unless every ingredient has the required amount
            for (int j = 0; j < ingredientRequirements.Count; j++)
            {
                Debug.Log("Checking " + ingredientRequirements[j].ingredientSO.ingredientName);
                //Checks if even one of the requirements isn't enough and if so, returns out
                //Once all ingredients have enough of the quantity, currentRecipe is successful
                if (!ingredientRequirements[j].hasEnough)
                {
                    Debug.Log("Not enough " + ingredientRequirements[j].ingredientSO.ingredientName);
                    return;
                }
            }

            Debug.Log("Recipe Successful");
            if (currentRecipe.completedRecipe != null)
            {
                onRecipeCompleted.Invoke();             
                Runner.Spawn(currentRecipe.completedRecipe, spawnPoint.position, spawnPoint.rotation);
            }
            HealthyPlateManager.Instance.onRecipeSucceded.Invoke();
        }
    }

    public void PlayerJoined(PlayerRef player)
    {
        if (Object.HasStateAuthority)
        {
            RecipeProgressRPC(recipeIngredientsDisplay.text);
        }       
    }

    [Rpc]
    public void RecipeProgressRPC(string progressText)
    {
        recipeIngredientsDisplay.text = progressText;
    }

    public void ClearBoard()
    {
        recipeNameDisplay.text = "";
        recipeIngredientsDisplay.text = "";
        referenceImage.sprite = null;
    }    
}
