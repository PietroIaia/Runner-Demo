using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    // GameObject of player
    public GameObject Character;
    // offset on Y axis
    public float offset;


    void Update()
    {
        // The Equipment follows the player at all times
        this.transform.position = new Vector3(Character.transform.position.x, Character.transform.position.y + offset, this.transform.position.z);
    }
}
