using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Animator of player
    public Animator animator;
    // RigidBody of player
    private Rigidbody2D rb_2D;
    // Speed of player
    public float speed;
    // Jump speed of player
    public float acceleration;
    // Acceleration of player
    public float jump;
    // Checks if player is on the ground
    private bool grounded = false;
    //Starting Position
    private Vector3 start_pos;
    private despawner_traps despawner;
    

    private void Start()
    {
        // Obtenemos el componente Rigidbody2D
        rb_2D = GetComponent<Rigidbody2D>();
        start_pos = new Vector3(this.transform.position.x, 0, this.transform.position.z);
    }

    // FixedUpdate is used when we mess around with physics
    private void FixedUpdate()
    {
        // If speed reaches max Speed, it stops augmenting it
        if(speed < 16)
        {
            speed += Time.deltaTime * acceleration;
        }
        // The enemy has constant velocity
        rb_2D.velocity = new Vector2(speed, rb_2D.velocity.y);

        // The player is able to jump when he is on the ground.
        if(Input.GetKeyDown("space") && grounded)
        {
            rb_2D.AddForce(new Vector2(0f, jump));
            grounded = false;                             // **Ponemos grounded aqui en vez de OnCollisionExit2D() ya que puede tardar unos microsegundos en cambiarse y nos agrega una fuerza mucho mayor. En cambio aqui el cambio de grounded se realiza al instante.
        }
        
        // When the jump peaks, it returns faster to ground
        if(this.transform.position.y >= 0.1)
        {
            rb_2D.velocity = new Vector2(speed, -2.5f);
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
        // If the player touches the ground
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;

            // We do this to avoid inconsistencies on the jump height
            rb_2D.velocity = Vector3.zero;
            rb_2D.angularVelocity = 0f;
        }
    }

    // It register Collision with Triggers
    private void OnTriggerExit2D(Collider2D col)
    {
        // If it collides with Reset World, the character returns to starting position and resets the despawner counter
        if(col.name == "Reset World")
        {
            this.transform.position = start_pos + new Vector3(0, this.transform.position.y, 0);
            this.transform.GetChild(2).gameObject.GetComponent<despawner_traps>().no_despawn = 4;
        }
    }
}
