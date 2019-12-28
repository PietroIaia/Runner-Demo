using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    // Animator of enemy
    public Animator animator;
    // Speed of enemy
    public int speed;
    // Jump Speed of enemy
    public int jump;
    // RigidBody of enemy
    private Rigidbody2D rb;
    // Checks if enemy is on the ground
    private bool grounded = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is used when we mess around with physics
    void FixedUpdate()
    {
        // The enemy has constant velocity
        rb.velocity = new Vector2(speed, rb.velocity.y);

        // If the player jumps, the enemy does too
        if(Input.GetKeyDown("space"))
        {
            rb.AddForce(new Vector2(0f, jump));
            grounded = false;
        }

        // When the jump peaks, it returns faster to ground
        if(this.transform.position.y >= 0.1)
        {
            rb.velocity = new Vector2(speed, -2.5f);
        }
    }

    private void Update()
    {
        // We set the grounded parameter from the animator with the grounded variable
        animator.SetBool("grounded", grounded);
    }

    // With this we register Collision with objects
    private void OnCollisionEnter2D(Collision2D col) 
    {
        // Machete Layer number
        if(col.gameObject.layer == 11)
        {
            // If the machete collides with enemy, the enemy gets destroyed
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
