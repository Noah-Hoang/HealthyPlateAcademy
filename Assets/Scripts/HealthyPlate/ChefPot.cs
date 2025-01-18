using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefPot : CookingTool
{
    public override string cookingLocation { get; set; } = "SearingLocation";

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }

    public override IEnumerator CookingTime(Collider other)
    {
        Ingredient ingredientSetter = other.transform.GetComponentInParent<Ingredient>();
        timeUntilCooked = ingredientSetter.ingredientSO.timeUntilBoiled;
        nextFood = ingredientSetter.ingredientSO.boiledPrefab;
        destroyAfterCooked = ingredientSetter.ingredientSO.destroyAfterBoiled;

        return base.CookingTime(other);
    }

    public override IEnumerator Overcooked(Ingredient cookedFood)
    {
        return base.Overcooked(cookedFood);
    }
}
