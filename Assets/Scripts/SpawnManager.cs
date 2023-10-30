using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate); // Spawn obstacles on an interval
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); // Find the object named "Player" in the hierarchy and assign its PlayerController script to playerControllerScript variable
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        int randIndex = Random.Range(0, obstaclePrefabs.Length);

        // If the game is not over
        if (playerControllerScript.gameOver == false && randIndex != 9)
        {
            Instantiate(obstaclePrefabs[randIndex], spawnPos, obstaclePrefabs[randIndex].transform.rotation);
        }
        else if (playerControllerScript.gameOver == false && randIndex == 9)
        {
            Instantiate(obstaclePrefabs[randIndex], new Vector3(25, 0.5f, 0), obstaclePrefabs[randIndex].transform.rotation);
        }
    }
}
