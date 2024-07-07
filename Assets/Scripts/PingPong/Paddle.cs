using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 5f;
    public float speed2 = 5f;
    public GameObject capsule;
    public bool isPlayer1;

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (capsule == gameObject)
        {
            Debug.Log("Capsule");
            if ((Input.GetKey(KeyCode.W) && isPlayer1) || (Input.GetKey(KeyCode.I) && !isPlayer1))
            {
                Debug.Log("UP");
                moveY = 0.1f * speed * Time.deltaTime;
            }

            if ((Input.GetKey(KeyCode.S) && isPlayer1) || (Input.GetKey(KeyCode.K) && !isPlayer1))
            {
                Debug.Log("DOWN");
                moveY = -0.1f * speed * Time.deltaTime;
            }

            if ((Input.GetKey(KeyCode.A) && isPlayer1) || (Input.GetKey(KeyCode.J) && !isPlayer1))
            {
                Debug.Log("LEFT");
                moveX = -0.1f * speed2 * Time.deltaTime;
            }

            if ((Input.GetKey(KeyCode.D) && isPlayer1) || (Input.GetKey(KeyCode.L) && !isPlayer1))
            {
                Debug.Log("RIGHT");
                moveX = 0.1f * speed2 * Time.deltaTime;
            }
        }

        transform.Translate(0, moveY, 0);
        transform.Translate(moveX, 0, 0);
    }
}
