using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//Make singleton
//Create events (OnRecipeAssigned, OnRecipeSucceded, OnRecipeFailed)
//Create class that puts recipe on the board (Debug Log for now)
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

    [Header("Events")]
    public UnityEvent onRecipeAssigned;
    public UnityEvent onRecipeSucceded;
    public UnityEvent onRecipeFailed;

    public List<int> recipeList;

    public float totalTime;
    public float remainingTime;

    public bool recipeOngoing;

    public int money;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;

        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecipeManager()
    {
        
    }
    [ContextMenu("Pick New Recipe")]
    public void ChooseRecipe()
    {
        int index = UnityEngine.Random.Range(0, recipeList.Count);       
        int recipeIndex = recipeList[index];
        Debug.Log("Recipe Is:" + recipeIndex);

        if (!recipeOngoing)
        {
            onRecipeAssigned.Invoke();
            recipeOngoing = true;
        }
    }

    public void RecipeTimer()
    {
        if (remainingTime > 0 && recipeOngoing)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (recipeOngoing)
        {
            money -= 5;
            recipeOngoing = false;
            onRecipeFailed.Invoke();
        }
    }
}
