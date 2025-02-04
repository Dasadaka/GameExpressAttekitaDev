﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstacles;
    public List<Obstacle> obstaclesToSpawn;

    void Start()
    {
        InitObstacles();

        StartCoroutine(SpawnRandomObstacles());
    }

    void InitObstacles()
    {
        int index = 0;
        for(int i = 0; i < obstacles.Length * 3; i++)
        {
            GameObject obj = Instantiate(obstacles[index], transform.position, Quaternion.identity);
            obj.SetActive(false);
            obstaclesToSpawn.Add(obj.GetComponent<Obstacle>());

            index++;
            if(index == obstacles.Length)
            {
                index = 0;
            }

        }


    }

    IEnumerator SpawnRandomObstacles()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 5f));

        int index = Random.Range(0, obstaclesToSpawn.Count);

        while (true)
        {
            Obstacle obstacle = obstaclesToSpawn[index];

            if (!obstacle.gameObject.activeInHierarchy)
            {
                obstacle.gameObject.SetActive(true);
                obstacle.transform.position = transform.position;
                break;
            }
            else
            {
                index = Random.Range(0, obstaclesToSpawn.Count);
            }
            
        }
        
        StartCoroutine(SpawnRandomObstacles());
    }
}
