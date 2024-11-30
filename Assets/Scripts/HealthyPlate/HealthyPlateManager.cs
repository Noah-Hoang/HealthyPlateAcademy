using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HealthyPlateManager : NetworkBehaviour
{
    public static HealthyPlateManager Instance { get; private set; }
    public static bool isInstructorMode;

    [Networked]
    public int currentRecipeIndex { get; set; }

    [Header("General")]
    public float totalTime;

    // Networked Tick Timer for synchronization
    [Networked]
    private TickTimer recipeTickTimer { get; set; } 

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

    //Called when a player spawns in

    public override void Spawned()
    {
        base.Spawned();

        //Checks to see if theres a recipe ongoing and if there is, calls StartRecipeRPC for any late joiners
        if (currentRecipeIndex > -100)
        {
            StartRecipeRPC();
        }
    }

    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();

        // Only the state authority (host) manages the timer logic
        //Host sends out timer for everybody
        if (Object.HasStateAuthority) 
        {
            UpdateRecipeTimer();
        }
        DisplayRemainingTime();
    }

    [ContextMenu("Test Recipe")]
    public void TestRecipe()
    {
        currentRecipeIndex = -1;
        StartRecipeRPC();
    }

    public void ChooseRecipe()
    {
        if (!recipeOngoing)
        {
            // Start the tick timer
            recipeTickTimer = TickTimer.CreateFromSeconds(Runner, totalTime); 
            currentRecipeIndex = UnityEngine.Random.Range(0, recipeList.Count);
            StartRecipeRPC();
        }
    }  

    [Rpc]
    private void StartRecipeRPC()
    {
        if (recipeOngoing) 
        {
            return;
        }

        RecipeSO selectedRecipe = null;

        //Checks to see if the Test Recipe was chosen
        if (currentRecipeIndex == -1)
        {
            selectedRecipe = testRecipe;
        }
        else
        {
            selectedRecipe = recipeList[currentRecipeIndex];
        }
        recipeOngoing = true;
        onRecipeAssigned.Invoke(selectedRecipe);
    }

    private void UpdateRecipeTimer()
    {
        if (recipeTickTimer.Expired(Runner) && recipeOngoing)
        {
            recipeOngoing = false;
            onRecipeFailed.Invoke();
        }
    }

    private void DisplayRemainingTime()
    {
        if (recipeOngoing)
        {
            // Calculate seconds remaining based on the tick timer
            float secondsRemaining = recipeTickTimer.RemainingTime(Runner).GetValueOrDefault(0);
            int seconds = Mathf.FloorToInt(secondsRemaining);
            timerText.text = seconds.ToString();
        }
        else
        {
            timerText.text = "0";
        }
    }

    public void RecipeSucceded()
    {
        //currentRecipeIndex set to -100 is the base for when there is no recipe ongoing
        currentRecipeIndex = -100;
        recipeOngoing = false;
        money += 20;
    }

    public void RecipeFailed()
    {
        //currentRecipeIndex set to -100 is the base for when there is no recipe ongoing
        currentRecipeIndex = -100;
        recipeOngoing = false;
        money -= 5;
    }
}
