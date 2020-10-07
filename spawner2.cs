﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner2 : MonoBehaviour
{
    public GameObject enemy;
    Vector2 whereToSpawn;
    public float spawnRate = 10f;
    float nextSpawn = 15f;
    public GameObject Spawner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            
            nextSpawn = Time.time + spawnRate;
            whereToSpawn = new Vector2(Spawner.transform.position.x, Spawner.transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
    }


}
