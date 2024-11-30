using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private GameObject gun;
    [SerializeField]
    private GameObject attractorPrefab;
    [SerializeField]
    private GameObject repulsorPrefab;
    [SerializeField]
    private GameObject cursor;

    Quaternion rotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        GetInput();
    }
    
    private void Aim()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor.transform.position = cursorPosition;
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        gun.transform.rotation = rotation;
    }
    private void GetInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootAttractor();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            ShootRepulsor();
        }
    }

    public void ShootAttractor()
    {
        Instantiate(attractorPrefab, gun.transform.position+gun.transform.right, rotation);
    }
    public void ShootRepulsor()
    {
        Instantiate(repulsorPrefab, gun.transform.position + gun.transform.right, rotation);
    }
}
