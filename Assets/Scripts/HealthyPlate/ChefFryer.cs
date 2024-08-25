using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefFryer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.tag == "Ingredient")
        {
            Instantiate(other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.friedPrefab, other.transform.root.position, other.transform.root.rotation);
            Destroy(other.transform.root.gameObject);
        }
    }
}
