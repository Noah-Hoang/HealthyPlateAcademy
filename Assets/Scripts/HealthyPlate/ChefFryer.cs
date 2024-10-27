using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class ChefFryer : NetworkBehaviour
{
    // Dictionary to store coroutines for each ingredient
    private Dictionary<Ingredient, Coroutine> ingredientCoroutines = new Dictionary<Ingredient, Coroutine>();

    public ParticleSystem cookingEffect;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.tag == "Ingredient")
        {
            if (other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.friedPrefab == null)
            {
                return;
            }

            // Get the ingredient object
            Ingredient ingredient = other.transform.GetComponentInParent<Ingredient>();

            // Start the coroutine for this specific ingredient if it's not already being fried
            if (!ingredientCoroutines.ContainsKey(ingredient))
            {
                cookingEffect.Play();
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
        }
    }

    public IEnumerator FryTime(Collider other)
    {
        Ingredient ingredient = other.transform.GetComponentInParent<Ingredient>();

        yield return new WaitForSeconds(ingredient.GetComponent<Ingredient>().ingredientSO.timeUntilFried);

        // Only proceed if the ingredient is still in the dictionary (i.e., it hasn't left the pan)
        if (ingredientCoroutines.ContainsKey(ingredient))
        {
            Runner.Spawn(ingredient.GetComponent<Ingredient>().ingredientSO.friedPrefab, ingredient.transform.position, ingredient.transform.rotation);

            if (ingredient.GetComponent<Ingredient>().ingredientSO.destroyAfterFried)
            {
                Runner.Despawn(ingredient.GetComponent<NetworkObject>());
            }

            // Remove the ingredient from the dictionary once the frying is complete
            ingredientCoroutines.Remove(ingredient);

            if (ingredientCoroutines.Count == 0)
            {
                cookingEffect.Stop();
            }
        }
    }
}
