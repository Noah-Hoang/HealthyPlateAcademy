using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{   
    public float speed = 5f;

    void Update()
    {
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, moveY, 0);
    }
}
