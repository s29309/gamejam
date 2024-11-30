using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class Attractor : MonoBehaviour
{
    public LayerMask attractionLayer;
    public float gravity = 10;
    [SerializeField] private float radius = 10;
    public List<Collider2D> attractedObjects = new List<Collider2D>();

    void Update()
    {
        UpdateAttractedObjects();
    }

    void FixedUpdate()
    {
        AttractObjects();
    }

    void UpdateAttractedObjects()
    {
        attractedObjects = Physics2D.OverlapCircleAll(transform.position, radius, attractionLayer).ToList();
    }

    void AttractObjects()
    {
        for (int i = 0; i < attractedObjects.Count; i++)
        {
            attractedObjects[i].GetComponent<Attractable>().Attract(this);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}