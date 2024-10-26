using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


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
public class HealthyPlateManager : MonoBehaviour
{
    public static HealthyPlateManager Instance { get; private set; }

    [Header("General")]
    public float totalTime;
    public float remainingTime;
    public bool recipeOngoing;
    public int money;
    public RecipeSO testRecipe;
    public List<RecipeSO> recipeList;
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

    [ContextMenu("Test Recipe")]
    public void TestRecipe()
    {
        remainingTime = totalTime;
        recipeOngoing = true;
        onRecipeAssigned.Invoke(testRecipe);
    }

    public void ChooseRecipe()
    {
        if (!recipeOngoing)
        {
            remainingTime = totalTime;
            recipeOngoing = true;

            int index = UnityEngine.Random.Range(0, recipeList.Count);
            RecipeSO recipeSO = recipeList[index];

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
        recipeOngoing = false;
        money += 20;
    }

    public void RecipeFailed()
    {
        recipeOngoing = false;
        money -= 5;
    }
}
