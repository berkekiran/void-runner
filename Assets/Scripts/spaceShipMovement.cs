using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spaceShipMovement : MonoBehaviour
{
    public Transform leftFirePosition;
    public Transform rightFirePosition;
    public GameObject bullet;
    public float hiz = 0.5f;
    private int movePosition = 1;
    public GameObject score;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject fireButton;
    public GameObject startButton;
    public GameObject replayButton;
    public GameObject InGameReplayButton;
    public GameObject background;
    public GameObject scoreEnd;
    public GameObject Logo;
    public GameObject LogoEnd;
    private bool isThisEnd = true;

    void Start()
    {
        Time.timeScale = 0;
        score.SetActive(false);
        scoreEnd.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        replayButton.SetActive(false);
        fireButton.SetActive(false);
        startButton.SetActive(true);
        background.SetActive(true);
        InGameReplayButton.SetActive(false);
        Logo.SetActive(true);
        LogoEnd.SetActive(false);
    }

    public void StartGame(){
        Time.timeScale = 1;
        score.SetActive(true);
        scoreEnd.SetActive(false);
        leftButton.SetActive(true);
        replayButton.SetActive(false);
        rightButton.SetActive(true);
        fireButton.SetActive(true);
        background.SetActive(false);
        startButton.SetActive(false);
        InGameReplayButton.SetActive(true);
        Logo.SetActive(false);
        LogoEnd.SetActive(false);
    }
    
    void Update()
    {

        score.GetComponent<Text>().text = ManagerScript.Instance.Score.ToString();
        scoreEnd.GetComponent<Text>().text = ManagerScript.Instance.Score.ToString();

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
    }

    public void left()
    {
        if(movePosition > 0)
            movePosition--;
    }
    public void right()
    {
        if(movePosition < 2)
            movePosition++;
    }

    public void fire()
    {
        Instantiate(bullet, rightFirePosition.transform.position, new Quaternion());
        Instantiate(bullet, leftFirePosition.transform.position, new Quaternion());
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("BulletEnemy")){
            isThisEnd = true;
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.125f);
        if(isThisEnd){
            Time.timeScale = 0;
            score.SetActive(false);
            scoreEnd.SetActive(true);
            leftButton.SetActive(false);
            replayButton.SetActive(true);
            rightButton.SetActive(false);
            fireButton.SetActive(false);
            background.SetActive(true);
            startButton.SetActive(false);
            InGameReplayButton.SetActive(false);
            Logo.SetActive(false);
            LogoEnd.SetActive(true);
            isThisEnd = false;
        }
    }

    public void Replay(){
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        ManagerScript.Instance.Score = 0;
        movePosition = 1;
        Time.timeScale = 1;
        score.SetActive(true);
        scoreEnd.SetActive(false);
        leftButton.SetActive(true);
        rightButton.SetActive(true);
        fireButton.SetActive(true);
        background.SetActive(false);
        replayButton.SetActive(false);
        startButton.SetActive(false);
        InGameReplayButton.SetActive(true);
        Logo.SetActive(false);
        LogoEnd.SetActive(false);
    }

}
