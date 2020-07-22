using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceShipMovement : MonoBehaviour
{
    Rigidbody rb;
    int guc = 1;
    public Transform leftFirePosition;
    public Transform rightFirePosition;
    public GameObject bullet;
    public float hiz = 0.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        this.GetComponent<Rigidbody>().MovePosition(transform.position + Vector3.forward * hiz);
        
    }

    public void left()
    {
        
        transform.position += new Vector3(-guc, 0, 0);
    }
    public void right()
    {
        transform.position += new Vector3(guc, 0, 0);
    }
    public void fire()
    {
        Instantiate(bullet, rightFirePosition.transform.position, new Quaternion());
        Instantiate(bullet, leftFirePosition.transform.position, new Quaternion());
    }

}
