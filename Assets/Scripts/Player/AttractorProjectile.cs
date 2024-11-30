using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttractorProjectile : MonoBehaviour
{
    Rigidbody2D rigidbody;
    [SerializeField]
    private GameObject attractorPrefab;
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
        if(collision.collider.CompareTag("Ground")||collision.collider.CompareTag("Platform"))
        {
            GameObject attractor = Instantiate(attractorPrefab, transform.position, transform.rotation);
            Object.FindObjectOfType<BallManager>().setAttractor(attractor);
            //Attractor attractorScript = attractor.GetComponent<Attractor>();
            //attractor.transform.SetParent(collision.transform, true);
        }
        Destroy(gameObject);
    }
}
