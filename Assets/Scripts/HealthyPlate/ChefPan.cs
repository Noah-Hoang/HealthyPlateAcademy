using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class ChefPan : NetworkBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.tag == "Ingredient")
        {
            if (other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.searedPrefab == null)
            {
                return;
            }
            Runner.Spawn(other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.searedPrefab,other.transform.root.position, other.transform.root.rotation);
            if (other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.destroyAfterSeared)
            {
                Runner.Despawn(other.transform.root.gameObject.GetComponent<NetworkObject>());
            }
        }
    }
}