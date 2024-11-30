using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        if (grounded)
        {
            rigidbody.velocity = new Vector2(speed * directionX, rigidbody.velocity.y);
            return;
        }
        rigidbody.velocity = new Vector2(rigidbody.velocity.x + speed*0.05f * directionX, rigidbody.velocity.y);
    }
    private void CheckGround()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckSize, groundLayer);
    }
    private void OnDrawGizmos()
    {
        CheckGround();
        if (grounded) { Gizmos.color = Color.red; }
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckSize);
    }
}
