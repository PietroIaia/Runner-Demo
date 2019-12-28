using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;              // This was manually added 

public class Death : MonoBehaviour
{
    // boolean that tells if the character died
    private bool dead = false;
    private float time_to_respawn;
    private float timer;
    public GameObject MainCamera;
    private CameraShake shake;

    void Start()
    {
        
        shake = MainCamera.GetComponent<CameraShake>();
    }

    void Update()
    {
        // If the player dies, it restart the Scene.
        if(dead == true)
        {
            Time.timeScale = 0;
            timer += Time.unscaledDeltaTime;      // unscaledDeltaTime: DeltaTime no afectado por timeScale.
            time_to_respawn = timer % 60;
            if(time_to_respawn >= 1)
            {
                SceneManager.LoadScene( SceneManager.GetActiveScene().name );
                Time.timeScale = 1;
            }
        }
    }

    // With this we register Particle Collision (Remember to activate "Send Collision Message" on the Particle system)
    protected void OnParticleCollision(GameObject other) 
    {   
        // If the player collides with these particle systems, he dies
        if(other.name == "rain particles")
        {
            shake.shakeDuration = 0.10f;
            dead = true;
        }
        if(other.name == "Arrow")
        {
            shake.shakeDuration = 0.10f;
            dead = true;
        }
    }

    // With this we register Collision with objects
    private void OnCollisionEnter2D(Collision2D col) 
    {
        // 12 is the enemy layer number
        if(col.gameObject.layer == 12)
        {
            shake.shakeDuration = 0.10f;
            dead = true;
        }  
    }
}
