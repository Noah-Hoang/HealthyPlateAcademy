using UnityEngine;
using Fusion;

public class NetworkedBall : NetworkBehaviour
{
    public float initialSpeed = 10f;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void Spawned()
    {
        if (Object.HasStateAuthority)
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        Vector3 direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f).normalized;
        rb.velocity = direction * initialSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Object.HasStateAuthority)
        {
            // Handle ball collision logic, e.g., changing direction
            Vector3 newDirection = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            rb.velocity = newDirection * initialSpeed;
        }
    }
}