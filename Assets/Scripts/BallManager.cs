using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    GameObject attractor;
    GameObject repulsor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setAttractor(GameObject newAttractor)
    {
        if(attractor != null)
        {
            Destroy(attractor);
        }
        attractor = newAttractor;
    }
    public void setRepulsor(GameObject newRepulsor)
    {
        if (repulsor != null)
        {
            Destroy(repulsor);
        }
        repulsor = newRepulsor;
    }
}
