using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableIndicator : MonoBehaviour
{
    public Canvas canvas;
    public Image image;
    public Sprite knifeIcon;
    public Sprite panIcon;
    public Sprite fryerIcon;

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
                    image.sprite = knifeIcon;
                    canvas.enabled = true;
                }
            }
            else if (obj.GetComponent<ChefPan>() != null)
            {
                if (gameObject.GetComponent<Ingredient>().ingredientSO.searedPrefab != null)
                {
                    image.sprite = panIcon;
                    canvas.enabled = true;
                }
            }
            else if (obj.GetComponent<ChefFryer>() != null)
            {
                if (gameObject.GetComponent<Ingredient>().ingredientSO.friedPrefab != null)
                {
                    image.sprite = fryerIcon;
                    canvas.enabled = true;
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
                    canvas.enabled = false;
                }
            }
            else if (obj.GetComponent<ChefPan>() != null)
            {
                if (gameObject.GetComponent<Ingredient>().ingredientSO.searedPrefab != null)
                {
                    canvas.enabled = false;
                }
            }
            else if (obj.GetComponent<ChefFryer>() != null)
            {
                if (gameObject.GetComponent<Ingredient>().ingredientSO.friedPrefab != null)
                {
                    canvas.enabled = false;
                }
            }
        }
    }
}
