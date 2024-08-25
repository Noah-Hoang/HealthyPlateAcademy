using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefKnife : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.gameObject.tag == "Ingredient")
        {
            Instantiate(collision.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.cutPrefab,collision.transform.root.position, collision.transform.root.rotation);
            Destroy(collision.transform.root.gameObject);
        }
    }
}
