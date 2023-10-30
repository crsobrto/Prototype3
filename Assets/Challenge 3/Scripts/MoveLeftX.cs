using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    private PlayerControllerX playerControllerScript;
    private Rigidbody rb;

    public float speed;
    private float leftBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        rb = GetComponent<Rigidbody>();

        if (rb != null) // Used to check against the background, which does not have a rigidbody
        {
            rb.useGravity = false;
            rb.drag = 1.0f;
            rb.angularDrag = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if (playerControllerScript.gameOver == false)
        {
            if (rb == null)
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            else
                rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }

    }
}
