using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawn : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPt;
    int max = 10;
    float spawntime = 0;
    int randum;

    void Start()
    {
        //Instantiate(enemy, spawnPt.position, Quaternion.identity);
    }

    void Update()
    {
        spawntime += Time.deltaTime;
        randum = Random.Range(0, 5);
        if(spawntime > 2)
        {
            Instantiate(enemy, spawnPt[randum].position, Quaternion.identity);
            spawntime = 0;
        }
    }
}
