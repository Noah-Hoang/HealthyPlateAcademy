using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedPaddle : MonoBehaviour
{
    public float speed = 5f;
    public float speed2 = 5f;
    public GameObject capsule;

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (capsule == gameObject)
        {
            Debug.Log("Capsule");
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("UP");
                moveY = 0.1f * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                Debug.Log("DOWN");
                moveY = -0.1f * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("LEFT");
                moveX = -0.1f * speed2 * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                Debug.Log("RIGHT");
                moveX = 0.1f * speed2 * Time.deltaTime;
            }
        }

        transform.Translate(0, moveY, 0);
        transform.Translate(moveX, 0, 0);
    }
}
