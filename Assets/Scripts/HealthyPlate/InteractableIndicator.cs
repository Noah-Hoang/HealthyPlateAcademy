using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableIndicator : MonoBehaviour
{
    public Canvas image;
    // Start is called before the first frame update
    private void OnEnable()
    {
        NetworkedGrab.OnObjectGrabbedStatic.AddListener(DisplayImage);
        NetworkedGrab.OnObjectReleasedStatic.AddListener(DisableImage);
    }

    private void OnDisable()
    {
        NetworkedGrab.OnObjectGrabbedStatic.RemoveListener(DisplayImage);
        NetworkedGrab.OnObjectReleasedStatic.RemoveListener(DisableImage);
    }



    public void DisplayImage(GameObject obj, bool isLeftHand)
    {
        if (obj.tag == "CookingTool")
        {
            if (obj.GetComponent<ChefKnife>() != null)
            {
                if (gameObject.GetComponent<Ingredient>().ingredientSO.cutPrefab != null)
                {
                    image.enabled = true;
                }
            }
            else if (obj.GetComponent<ChefPan>() != null)
            {
                if (gameObject.GetComponent<Ingredient>().ingredientSO.searedPrefab != null)
                {
                    image.enabled = true;
                }
            }
            else if (obj.GetComponent<ChefFryer>() != null)
            {
                if (gameObject.GetComponent<Ingredient>().ingredientSO.friedPrefab != null)
                {
                    image.enabled = true;
                }
            }
        }
    }

    public void DisableImage(GameObject obj, bool isLeftHand)
    {
        if (obj.tag == "CookingTool")
        {
            if (obj.GetComponent<ChefKnife>() != null)
            {
                if (gameObject.GetComponent<Ingredient>().ingredientSO.cutPrefab != null)
                {
                    image.enabled = false;
                }
            }
            else if (obj.GetComponent<ChefPan>() != null)
            {
                if (gameObject.GetComponent<Ingredient>().ingredientSO.searedPrefab != null)
                {
                    image.enabled = false;
                }
            }
            else if (obj.GetComponent<ChefFryer>() != null)
            {
                if (gameObject.GetComponent<Ingredient>().ingredientSO.friedPrefab != null)
                {
                    image.enabled = false;
                }
            }
        }
    }
}
