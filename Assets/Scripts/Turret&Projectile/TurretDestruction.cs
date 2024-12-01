using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDestruction : MonoBehaviour
{
    [SerializeField]
    private float destructionThreshold = 10f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Platform"))
        {
            float impactSpeed = collision.relativeVelocity.magnitude;

            if (impactSpeed > destructionThreshold)
            {
                Debug.Log(impactSpeed);
                Destroy(gameObject);
            }
        }
    }
}
