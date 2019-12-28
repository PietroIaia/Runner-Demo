using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_trigger : MonoBehaviour
{
    // GameObject of the thing to spawn
    public GameObject spawn;
    // Particle System
    private ParticleSystem particle;

    void Start()
    {
        // If the thing to spawn is a Particle System, we get its component
        if(spawn.name == "Arrow")
        {
            particle = spawn.GetComponent<ParticleSystem>();
        }
    }

    // This registers collision with triggers
    private void OnTriggerEnter2D(Collider2D col) {
        
        if(spawn.name == "Arrow")
        {
            // When the player enters the zone where the crossbow can shoot, the particle system starts playing.
            // And when he leaves that zone, the particle system stops playing
            if(col.gameObject.name == "Character")
            {   
                if(particle.isStopped)
                {
                    particle.Play();
                }
                else if(particle.isPlaying)
                {
                    particle.Stop();
                }
            }
        }
        // If the thing to spawn is not the Arrows
        else
        {
            // Works the same way as with the previous one, but with a gameObject and not with a particle system
            if(col.gameObject.name == "Character")
            {   
                if(spawn.activeInHierarchy == true)
                {
                    spawn.SetActive(false);
                }
                else if(spawn.activeInHierarchy == false)
                {
                    spawn.SetActive(true);
                }
            }
        }
    }
}
