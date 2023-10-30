using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // Record the start position of the background
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Get the size on the x-axis of the background's box collider and divide it by 2 to use to repeat the background seamlessly
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth) // The background is constantly moving to the left, so it's x value will be decreasing over time
        {
            transform.position = startPos; // Reset the background's current position to what it started at
        }
    }
}
