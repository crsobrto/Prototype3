using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Assign the player's Rigidbody component from the inspector to the playerRb variable
        playerAnim = GetComponent<Animator>(); // Assign the player's Animator component from the inspector to the playerAnim variable
        playerAudio = GetComponent<AudioSource>(); // Assign the player's AudioSource component from the inspector to the playerAudio variable
        Physics.gravity *= gravityModifier; // Modify the force of gravity
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) // If the player jumps AND they are currently on the ground AND the game is not over
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Make the player jump up immediately and fall back down using its Rigidbody
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig"); // "Jump_trig" is one of the parameters found in the Jumping layer
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f); // Play the jump sound effect once
        }
    }

    // Used when two colliders interact with each other
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // If the player collides with the ground
        {
            isOnGround = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")) // Else if the player collides with an obstacle
        {
            gameOver = true;
            Debug.Log("Game Over!!");
            playerAnim.SetBool("Death_b", true); // Set the "Death_b" variable found in the Death animation layer to true
            playerAnim.SetInteger("DeathType_int", 1); // Set the "DeathType_int" variable found in the Death animation layer to 1
            explosionParticle.Play(); // Play the explosion particle effect
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f); // Play the crash sound effect once
        }
    }
}
