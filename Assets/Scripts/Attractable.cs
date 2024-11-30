using UnityEngine;

public class Attractable : MonoBehaviour
{
    [SerializeField] private Attractor currentAttractor;
    [SerializeField] private float gravityStrength = 100;
    
    Collider2D _collider2D;
    Rigidbody2D _rigidbody2D;

    [SerializeField]
    float gravityScale = 1;

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (currentAttractor != null)
        {
            if (!currentAttractor.attractedObjects.Contains(_collider2D))
            {
                currentAttractor = null;
                return;
            }
            //_rigidbody2D.gravityScale = 0.5f;
        }
        else
        {
            //_rigidbody2D.gravityScale = gravityScale;
        }
    }

    public void Attract(Attractor attractor)
    {
        Vector2 attractionDir = ((Vector2)attractor.transform.position - _rigidbody2D.position).normalized;
        _rigidbody2D.AddForce(attractionDir * (attractor.gravity * gravityStrength * Time.fixedDeltaTime));

        if (currentAttractor == null) 
        {
            currentAttractor = attractor;
        }
    }
}