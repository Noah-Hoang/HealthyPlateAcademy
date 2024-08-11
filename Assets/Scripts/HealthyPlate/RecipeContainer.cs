using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecpieContainer : MonoBehaviour
{
    [System.Serializable]
    public struct IngredientRequirement
    {
        public int requiredQuantity;
        public int currentQuantity;
        public bool hasEnough;
    }

}
