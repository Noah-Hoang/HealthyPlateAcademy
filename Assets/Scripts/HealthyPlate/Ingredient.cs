using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public IngredientSO ingredientSO;
    public bool isCharred;
    public Material charredMaterial;

    //TODO: set bool to true, replace all mesh materials with charredMaterial, gets called from a separate script (ChefPan or ChefFryer)
    [ContextMenu("Char Ingredient")]
    public void CharIngredient()
    {
        isCharred = true;

        MeshRenderer[] renderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in renderers)
        {
            // Create a copy of the materials array
            Material[] newMaterials = renderer.materials;

            // Replace each material in the array with the charredMaterial
            for (int i = 0; i < newMaterials.Length; i++)
            {
                newMaterials[i] = charredMaterial;
            }

            // Assign the modified array back to the renderer
            renderer.materials = newMaterials;
        }
    }
}
