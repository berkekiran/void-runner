using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> enemyIns;
    public GameObject ship;
    public int valueZ;
    public AudioSource spawn;
    public static bool canSpawn = false;

    void Start()
    {

    }

    void Update()
    {

        if (enemyIns.Count < 1){
            if(Time.timeScale != 0)
              SpawnEnemy();
        }

        if(canSpawn){
        if (enemyIns[enemyIns.Count-1] == null){
            enemyIns.Remove(enemyIns[enemyIns.Count-1]);
            valueZ = 0;
            canSpawn = false;
        }
        }

    }
    

    public void SpawnEnemy()
    {
        valueZ = valueZ + 1000;
        enemyIns.Add(Instantiate(enemy, new Vector3(0, 0, valueZ), enemy.transform.rotation, GameObject.Find("Enemies").transform) as GameObject);
        spawn.Play();
    }
}