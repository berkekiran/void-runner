using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float hiz = 0.5f;
    private GameObject ship;
    public bool moveBack = false;
    private int movePosition = 3;
    private bool moveSide = false;
    private bool targetLock = true;
    public GameObject bullet;
    public Transform leftFirePosition;
    public Transform rightFirePosition;
    private bool scoreAdd = true;

    void Start()
    {
        ship = GameObject.Find("SpaceShip");
        scoreAdd = true;
    }

    void Update()
    {
        if(!moveBack && targetLock)
            this.GetComponent<Rigidbody>().MovePosition(transform.position + Vector3.back * hiz * 25);
        else
            this.GetComponent<Rigidbody>().MovePosition(transform.position + Vector3.forward * hiz);


        switch(movePosition){
            case 0:
                this.GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(transform.position, new Vector3(-12, transform.position.y, transform.position.z), 0.075f) + Vector3.forward * hiz);
            break;
            case 1:
                this.GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), 0.075f) + Vector3.forward * hiz);
            break;
            case 2:
                this.GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(transform.position, new Vector3(12, transform.position.y, transform.position.z), 0.075f) + Vector3.forward * hiz);
            break;
        }

        if(moveSide){
            StartCoroutine(RandomPosition());
        }

    }

     IEnumerator RandomPosition()
    {
        moveSide = false;
        yield return new WaitForSeconds(0.5f);
        movePosition = Random.Range(0,3);
        fire();
        yield return new WaitForSeconds(0.5f);
        moveSide = true;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            moveBack = true;
            moveSide = true;
            targetLock = false;
            Destroy(this.GetComponent<BoxCollider>());
        }
        if(other.tag == "Bullet")
            StartCoroutine(DestroyEnemy());
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.125f);
        Destroy(this.gameObject);
        if(scoreAdd){
            ManagerScript.Instance.Score += 1;
            scoreAdd = false;
        }
    }

    public void fire()
    {
        Instantiate(bullet, rightFirePosition.transform.position, new Quaternion());
        Instantiate(bullet, leftFirePosition.transform.position, new Quaternion());
    }

}
