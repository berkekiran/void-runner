using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject tunnel;
    public List<GameObject> roadIns;
    public GameObject ship;
    int valueZ;

    void Start()
    {

        valueZ = -25;
        for (int i = 0; i <25; i++) AddRoad();

    }

    void Update()
    {

        if (ship.transform.position.z > (valueZ - 25 * 20))
        {
            AddRoad();
            Destroy(roadIns[0]);
            roadIns.Remove(roadIns[0]);
        }

    }
    

    public void AddRoad()
    {

        valueZ = valueZ + 25;
        roadIns.Add(Instantiate(tunnel, new Vector3(0, 0, valueZ), tunnel.transform.rotation, GameObject.Find("Environment").transform) as GameObject);

    }
}