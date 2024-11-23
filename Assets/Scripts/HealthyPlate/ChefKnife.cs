using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.Events;

public class ChefKnife : NetworkBehaviour
{
    public UnityEvent onFoodCut;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.gameObject.tag == "Ingredient")
        {
            if (collision.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.cutPrefab == null)
            {
                return;
            }
            Runner.Spawn(collision.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.cutPrefab, collision.transform.root.position, collision.transform.root.rotation);
            if (collision.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.destroyAfterCut)
            {
                Runner.Despawn(collision.transform.root.gameObject.GetComponent<NetworkObject>());
                onFoodCut.Invoke();
            }
        }        
    }
}