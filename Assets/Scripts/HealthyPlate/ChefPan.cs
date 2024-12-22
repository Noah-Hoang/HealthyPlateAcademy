using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.Events;

public class ChefPan : NetworkBehaviour
{
    // Dictionary to store coroutines for each ingredient
    private Dictionary<Ingredient, Coroutine> ingredientCoroutines = new Dictionary<Ingredient, Coroutine>();

    public bool isOnSearingLocation;

    public UnityEvent onCookingStarted = new UnityEvent();
    public UnityEvent onCookingComplete = new UnityEvent();
    public UnityEvent onOvercookedFood = new UnityEvent();
    public UnityEvent onCookwareEnabled = new UnityEvent();
    public UnityEvent onCookwareDisabled = new UnityEvent();
    public static UnityEvent onCookingStartedStatic = new UnityEvent();
    public static UnityEvent onCookingCompleteStatic = new UnityEvent();
    public static UnityEvent onOvercookedFoodStatic = new UnityEvent();
    public static UnityEvent onCookwareEnabledStatic = new UnityEvent();
    public static UnityEvent onCookwareDisabledStatic = new UnityEvent();

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("SearLocation") && !isOnSearingLocation)
        {
            Debug.Log("HELLO");
            isOnSearingLocation = true;

            onCookwareEnabled.Invoke();
            onCookwareEnabledStatic.Invoke();

            // Going through all ingredients in the dictionary and replacing their values with the new coroutine
            foreach (var ingredient in ingredientCoroutines.Keys)
            {               
                Coroutine searingCoroutine = StartCoroutine(SearTime(ingredient.GetComponent<Collider>()));
                ingredientCoroutines[ingredient] = searingCoroutine;                
            }

            if (ingredientCoroutines.Count > 0)
            {
                onCookingStarted.Invoke();
                onCookingStartedStatic.Invoke();
            }
        }

        if (other.transform.root.CompareTag("Ingredient"))
        {
            Debug.Log("HELLO2");
            Ingredient ingredient = other.transform.root.GetComponent<Ingredient>();

            // Return early if the ingredient has no searedPrefab
            if (ingredient == null || ingredient.ingredientSO.searedPrefab == null)
            {
                return;
            }

            // Add the ingredient to the dictionary if not already present
            if (!ingredientCoroutines.ContainsKey(ingredient))
            {
                // Add ingredient with a null coroutine for now
                ingredientCoroutines.Add(ingredient, null);

                // Only start cooking if on the searing location
                if (isOnSearingLocation)
                {
                    Coroutine searingCoroutine = StartCoroutine(SearTime(other));
                    ingredientCoroutines[ingredient] = searingCoroutine;
                }
            }

            // Check if the dictionary is empty and invoke the event if this is the first ingredient
            if (ingredientCoroutines.Count == 1 && isOnSearingLocation) 
            {
                onCookingStarted.Invoke();
                onCookingStartedStatic.Invoke();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.root.gameObject.tag == "SearLocation" && isOnSearingLocation)
        {
            Debug.Log("HELLO3");

            isOnSearingLocation = false;

            onCookwareDisabled.Invoke();
            onCookwareDisabledStatic.Invoke();

            // Convert the dictionary values to a list to stop all coroutines
            List<Coroutine> valuesList = new List<Coroutine>(ingredientCoroutines.Values);
            for (int i = 0; i < valuesList.Count; i++)
            {
                if (valuesList[i] != null)
                {
                    StopCoroutine(valuesList[i]);
                }
            }

            if (ingredientCoroutines.Count > 0)
            {
                onCookingComplete.Invoke();
                onCookingCompleteStatic.Invoke();
            }
        }

        if (other.transform.root.gameObject.tag == "Ingredient")
        {
            // Getting the ingredient class on the object
            Ingredient ingredient = other.transform.GetComponentInParent<Ingredient>();

            // If the food leaves the pan, stop its specific coroutine
            if (ingredientCoroutines.ContainsKey(ingredient))
            {
                // Checks to see if there is a coroutine to stop before attempting to stop it
                if (ingredientCoroutines[ingredient] != null)
                {
                    StopCoroutine(ingredientCoroutines[ingredient]);
                }
                ingredientCoroutines.Remove(ingredient); // Remove the coroutine from the dictionary
            }

            if (ingredientCoroutines.Count == 0)
            {
                onCookingComplete.Invoke();
                onCookingCompleteStatic.Invoke();
            }
        }
    }

    public IEnumerator SearTime(Collider other)
    {
        Ingredient ingredient = other.transform.GetComponentInParent<Ingredient>();
        Ingredient cookedFood = null;

        yield return new WaitForSeconds(ingredient.GetComponent<Ingredient>().ingredientSO.timeUntilSeared);

        // Only proceed if the ingredient is still in the dictionary (i.e., it hasn't left the pan)
        if (ingredientCoroutines.ContainsKey(ingredient))
        {
            cookedFood = Runner.Spawn(ingredient.GetComponent<Ingredient>().ingredientSO.searedPrefab, ingredient.transform.position, ingredient.transform.rotation).GetComponent<Ingredient>();

            // Checks to see if ingredient put in pan has been added to the dictionary yet.
            //If it has not, starts the SearTime Coroutine and adds ingredient and coroutine to dictionary
            if (!ingredientCoroutines.ContainsKey(cookedFood))
            {
                Coroutine overcookedCoroutine = StartCoroutine(Overcooked(cookedFood));
                ingredientCoroutines.Add(cookedFood, overcookedCoroutine);
            }

            // Remove the ingredient from the dictionary once the searing is complete
            ingredientCoroutines.Remove(ingredient);

            if (ingredient.GetComponent<Ingredient>().ingredientSO.destroyAfterSeared)
            {
                Runner.Despawn(ingredient.GetComponent<NetworkObject>());
            }            

            if (ingredientCoroutines.Count == 0) 
            {
                onCookingComplete.Invoke();
                onCookingCompleteStatic.Invoke();
            }            
        }       
    }

    public IEnumerator Overcooked(Ingredient cookedFood)
    {
        yield return new WaitForSeconds(5.0f);

        if ((cookedFood != null) && ingredientCoroutines.ContainsKey(cookedFood))
        {
            cookedFood.CharIngredient();

            onOvercookedFood.Invoke();
            onOvercookedFoodStatic.Invoke();
        }
    }
}
