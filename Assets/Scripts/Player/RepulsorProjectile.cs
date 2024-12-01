using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RepulsorProjectile : MonoBehaviour
{
    Rigidbody2D rigidbody;
    [SerializeField]
    private GameObject repulsorPrefab;
    [SerializeField]
    float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        rigidbody.velocity = transform.right * speed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Platform")||collision.collider.CompareTag("Catcher"))
        {
            GameObject repulsor = Instantiate(repulsorPrefab, transform.position, transform.rotation);
            Object.FindObjectOfType<BallManager>().setRepulsor(repulsor);
            Attractor repulsorScript = repulsor.GetComponent<Attractor>();
            //attractor.transform.SetParent(collision.transform, true);
        }
        else if (collision.collider.CompareTag("GravityPoint"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
