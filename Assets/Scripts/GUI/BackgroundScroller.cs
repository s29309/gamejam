using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float scrollSpeed = 1f;

    private float initialYOffset;

    void Start()
    {
        initialYOffset = transform.position.y - cameraTransform.position.y;
    }

    void Update()
    {
        float newYPosition = cameraTransform.position.y;
        transform.position = new Vector3(transform.position.x, newYPosition * scrollSpeed, transform.position.z);
    }
}
