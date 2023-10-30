using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30.0f;
    private PlayerController playerControllerScript;
    private float leftBound = -15.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); // Assign the player's PlayerController script to the playerControllerScript variable
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false) // If the game is not over
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed); // Move left
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) // If any obstacle goes beyound the left boundary
        {
            Destroy(gameObject); // Destroy the obstacle
        }
    }
}
