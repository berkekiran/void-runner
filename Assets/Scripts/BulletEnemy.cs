using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletEnemy : MonoBehaviour
{
    public AudioSource fireVoice;
    public float hiz = 3f;
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    
    void FixedUpdate()
    {
        transform.position -= new Vector3(0, 0, hiz*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        fireVoice.Play();
        if(other.tag == "Player")
            Destroy(this.gameObject);
    }
}
