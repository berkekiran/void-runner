using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceShipMovement : MonoBehaviour
{
    public float hiz = 0.5f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 vector = new Vector3(horizontal, 0, vertical);
        rb.AddForce(vector * hiz);

        
    }
}
