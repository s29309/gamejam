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
    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
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
        StartCoroutine(Recover());
    }
    private void OnDrawGizmos()
    {
        CheckGround();
        if (grounded) { Gizmos.color = Color.red; }
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckSize);
    }

    private IEnumerator Recover()
    {
        rigidbody.constraints = RigidbodyConstraints2D.None;

        yield return new WaitForSeconds(1);
        float duration = 0.5f;
        float elapsed = 0f;
        float initialRotation = rigidbody.rotation;

        Vector2 initialBottom = GetColliderBottomPosition();

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            float newRotation = Mathf.Lerp(initialRotation, 0f, t);
            rigidbody.MoveRotation(newRotation);

            Vector2 newBottom = GetColliderBottomPosition();
            Vector2 positionAdjustment = initialBottom - newBottom;

            rigidbody.MovePosition(rigidbody.position + positionAdjustment);

            yield return null;
        }

        rigidbody.rotation = 0f;

        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        stunned = false;
    }

    private Vector2 GetColliderBottomPosition()
    {
        // Get the collider's bounds and calculate the bottom position
        Bounds bounds = collider.bounds;
        return new Vector2(bounds.center.x, bounds.min.y);
    }
}
