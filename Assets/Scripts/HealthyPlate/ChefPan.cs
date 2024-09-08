using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefPan : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.tag == "Ingredient")
        {
            if (other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.searedPrefab == null)
            {
                return;
            }
            Instantiate(other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.searedPrefab,other.transform.root.position, other.transform.root.rotation);
            if (other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.destroyAfterSeared)
            {
                Destroy(other.transform.root.gameObject);
            }
        }
    }
}