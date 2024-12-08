using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.Events;

public class ChefFryer : NetworkBehaviour
{
    // Dictionary to store coroutines for each ingredient
    private Dictionary<Ingredient, Coroutine> ingredientCoroutines = new Dictionary<Ingredient, Coroutine>();

    public UnityEvent onCookingFoodStarted;
    public UnityEvent onCookingFoodComplete;
    public UnityEvent onOvercookedFood;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.tag == "Ingredient")
        {
            if (other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.friedPrefab == null)
            {
                return;
            }

            //Checks to see if the Dictionary is empty and if it is, when food is added to pan, it will be the first one and call the event
            if (ingredientCoroutines.Count == 0)
            {
                onCookingFoodStarted.Invoke();
            }

            // Get the ingredient object
            Ingredient ingredient = other.transform.GetComponentInParent<Ingredient>();

            // Start the coroutine for this specific ingredient if it's not already being fried
            if (!ingredientCoroutines.ContainsKey(ingredient))
            {
                Coroutine fryingCoroutine = StartCoroutine(FryTime(other));
                ingredientCoroutines.Add(ingredient, fryingCoroutine);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.root.gameObject.tag == "Ingredient")
        {
            // Get the ingredient object
            Ingredient ingredient = other.transform.GetComponentInParent<Ingredient>();

            // If the food leaves the pan, stop its specific coroutine
            if (ingredientCoroutines.ContainsKey(ingredient))
            {
                StopCoroutine(ingredientCoroutines[ingredient]);
                ingredientCoroutines.Remove(ingredient); // Remove the coroutine from the dictionary
            }

            if (ingredientCoroutines.Count == 0)
            {
                onCookingFoodComplete.Invoke();
            }
        }
    }

    public IEnumerator FryTime(Collider other)
    {
        Ingredient ingredient = other.transform.GetComponentInParent<Ingredient>();
        Ingredient cookedFood = null;

        yield return new WaitForSeconds(ingredient.GetComponent<Ingredient>().ingredientSO.timeUntilFried);

        // Only proceed if the ingredient is still in the dictionary (i.e., it hasn't left the pan)
        if (ingredientCoroutines.ContainsKey(ingredient))
        {
            cookedFood = Runner.Spawn(ingredient.GetComponent<Ingredient>().ingredientSO.friedPrefab, ingredient.transform.position, ingredient.transform.rotation).GetComponent<Ingredient>();

            // Checks to see if ingredient put in pan has been added to the dictionary yet.
            //If it has not, starts the SearTime Coroutine and adds ingredient and coroutine to dictionary
            if (!ingredientCoroutines.ContainsKey(cookedFood))
            {
                Coroutine overcookedCoroutine = StartCoroutine(Overcooked(cookedFood));
                ingredientCoroutines.Add(cookedFood, overcookedCoroutine);
            }

            // Remove the ingredient from the dictionary once the searing is complete
            ingredientCoroutines.Remove(ingredient);

            if (ingredient.GetComponent<Ingredient>().ingredientSO.destroyAfterFried)
            {
                Runner.Despawn(ingredient.GetComponent<NetworkObject>());
            }

            if (ingredientCoroutines.Count == 0)
            {
                onCookingFoodComplete.Invoke();
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
        }
    }
}
