using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{
    public float hiz = 0.5f;
    void Start()
    {
        
    }

    
    void Update()
    {
        this.GetComponent<Rigidbody>().MovePosition(transform.position + Vector3.forward * hiz);
    }
}
