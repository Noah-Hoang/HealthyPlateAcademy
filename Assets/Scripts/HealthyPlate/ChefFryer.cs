using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefFryer : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.tag == "Ingredient")
        {
            if (other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.friedPrefab == null)
            {
                return;
            }
            Instantiate(other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.friedPrefab, other.transform.root.position, other.transform.root.rotation);
            Destroy(other.transform.root.gameObject);
        }
    }
}