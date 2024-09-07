using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


//Make singleton
//Create events (OnRecipeAssigned, OnRecipeSucceded, OnRecipeFailed)
//Create method that puts recipe on the board (Debug Log for now)
//Tracks when recipe is completed
//Timer for recipe creation and scales with number of players
//Money used to buy different outfits
//Use money to customize appliances
//RecipeContainer needs to call the OnRecipeSucceded event
//Needs list of recipes and randomly chooses. Doesn't choose the same one in succession
//OPTIONAL: Audio
public class HealthyPlateManager : MonoBehaviour
{
    public static HealthyPlateManager Instance { get; private set; }

    [Header("General")]
    public float totalTime;
    public float remainingTime;
    public bool recipeOngoing;
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

    [ContextMenu("Pick New Recipe")]
    public void ChooseRecipe()
    {
        if (!recipeOngoing)
        {
            remainingTime = totalTime;
            recipeOngoing = true;

            int index = UnityEngine.Random.Range(0, recipeList.Count);
            RecipeSO recipeSO = recipeList[index];
            //TODO: Where recipe is put on the board
            recipeNameDisplay.text = recipeSO.recipeName;
            recipeIngredientsDisplay.text = "";
            for (int i = 0; i < recipeSO.ingredientHolders.Count; i++)
            {
                recipeIngredientsDisplay.text += "\u2022" + recipeSO.ingredientHolders[i].ingredient.ingredientName + ": " + recipeSO.ingredientHolders[i].quantity + "\n";
            }

            onRecipeAssigned.Invoke(recipeSO);
        }
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
        money += 20;
        ChooseRecipe();
    }

    public void RecipeFailed()
    {
        money -= 5;
        ChooseRecipe();
    }
}
