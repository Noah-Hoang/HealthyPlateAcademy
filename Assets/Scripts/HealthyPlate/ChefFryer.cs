using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class ChefFryer : NetworkBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.tag == "Ingredient")
        {
            if (other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.friedPrefab == null)
            {
                return;
            }
            Runner.Spawn(other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.friedPrefab, other.transform.root.position, other.transform.root.rotation);
            if (other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.destroyAfterFried)
            {
                Runner.Despawn(other.transform.root.gameObject.GetComponent<NetworkObject>());
            }
        }
    }
}