using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float hiz = 3f;
    void Start()
    {
        Destroy(gameObject, 4f);
    }

    
    void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, hiz*Time.deltaTime);
    }
}
