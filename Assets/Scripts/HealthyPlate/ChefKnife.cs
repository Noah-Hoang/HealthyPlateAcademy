using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefKnife : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.gameObject.tag == "Ingredient")
        {
            if (collision.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.cutPrefab == null)
            {
                return;
            }
            Instantiate(collision.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.cutPrefab,collision.transform.root.position, collision.transform.root.rotation);
            if (collision.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.destroyAfterCut)
            {
                Destroy(collision.transform.root.gameObject);
            }
        }
    }
}