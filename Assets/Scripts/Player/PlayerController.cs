using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float jumpHeight;
    [SerializeField]
    public float groundCheckSize;

    private float directionX;

    private bool grounded = false;
    private bool stunned = false;

    public Transform groundCheck;
    [SerializeField]
    public LayerMask groundLayer;
    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        Move();
        CheckGround();
    }

    private void GetInput()
    {
        directionX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    private void Jump()
    {
        if (grounded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpHeight);
        }
    }
    private void Move()
    {
        //if (grounded)
        //{
        if (stunned)
        {
            return;
        }
            rigidbody.velocity = new Vector2(speed * directionX, rigidbody.velocity.y);
        //    return;
        //}
        //rigidbody.velocity = new Vector2(rigidbody.velocity.x + speed*0.05f * directionX, rigidbody.velocity.y);
    }
    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckSize);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Ground") || collider.CompareTag("Platform"))
            {
                grounded = true;
                return;
            }
        }
        grounded = false;
    }

    public void Stun()
    {

        stunned = true;
    }
    private void OnDrawGizmos()
    {
        CheckGround();
        if (grounded) { Gizmos.color = Color.red; }
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckSize);
    }
    
}
