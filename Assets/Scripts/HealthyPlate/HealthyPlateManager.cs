using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Fusion;
using System;
using Unity.VisualScripting;


//Make singleton
//Create events (OnRecipeAssigned, OnRecipeSucceded, OnRecipeFailed)
//Create method that puts currentRecipe on the board (Debug Log for now)
//Tracks when currentRecipe is completed
//Timer for currentRecipe creation and scales with number of players
//Money used to buy different outfits
//Use money to customize appliances
//RecipeContainer needs to call the OnRecipeSucceded event
//Needs list of recipes and randomly chooses. Doesn't choose the same one in succession
//OPTIONAL: Audio
public class HealthyPlateManager : NetworkBehaviour
{
    public static HealthyPlateManager Instance { get; private set; }

    [Networked]
    public int selectedRecipeIndex { get; set; }

    [Networked, OnChangedRender(nameof(RecipeStarted))]
    public bool recipeOngoing { get; set; }

    [Header("General")]
    public float totalTime;
    public float remainingTime; 
    public int money;
    public List<RecipeSO> recipeList;
    public TMP_Text recipeNameDisplay;
    public TMP_Text recipeIngredientsDisplay;
    public TMP_Text timerText;

    [Header("Events")]
    public UnityEvent<RecipeSO> onRecipeAssigned;
    public UnityEvent onRecipeSucceded;
    public UnityEvent onRecipeFailed;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    void OnEnable()
    {
        onRecipeSucceded.AddListener(RecipeSucceded);
        onRecipeFailed.AddListener(RecipeFailed);
    }

    private void OnDisable()
    {
        onRecipeSucceded.RemoveListener(RecipeSucceded);
        onRecipeFailed.RemoveListener(RecipeFailed);
    }

    // Update is called once per frame
    void Update()
    {
        RecipeTimer();
    }

    public override void Spawned()
    {
        base.Spawned();

        if (recipeOngoing)
        {
            RecipeStarted();
        }
    }

    [ContextMenu("Pick New Recipe")]
    public void ChooseRecipe()
    {
        if (!recipeOngoing)
        {
            int index = UnityEngine.Random.Range(0, recipeList.Count);
            ChooseRecipeRPC(index);
        }
    }

    [Rpc]
    public void ChooseRecipeRPC(int index)
    {
        selectedRecipeIndex = index;
        recipeOngoing = true;
    }

    public void RecipeStarted()
    {
        remainingTime = totalTime;     
        RecipeSO recipeSO = recipeList[selectedRecipeIndex];
        //TODO: Where currentRecipe is put on the board
        recipeNameDisplay.text = recipeSO.ingredientName;
        recipeIngredientsDisplay.text = "";
        for (int i = 0; i < recipeSO.ingredientHolders.Count; i++)
        {
            recipeIngredientsDisplay.text += "\u2022" + recipeSO.ingredientHolders[i].ingredient.ingredientName + ": " + recipeSO.ingredientHolders[i].quantity + "\n";
        }

        onRecipeAssigned.Invoke(recipeSO);
    }

    public void RecipeTimer()
    {
        if (remainingTime > 0 && recipeOngoing)
        {
            remainingTime -= Time.deltaTime;
            int secondsRemaining = Mathf.FloorToInt(remainingTime);  // Convert float to integer seconds
            timerText.text = secondsRemaining.ToString();
        }
        else if (recipeOngoing)
        {         
            recipeOngoing = false;
            onRecipeFailed.Invoke();          
        }
    }

    public void RecipeSucceded()
    {
        recipeOngoing = false;
        money += 20;
    }

    public void RecipeFailed()
    {
        recipeOngoing = false;
        money -= 5;
    }
}
