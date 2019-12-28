using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossbow_move : MonoBehaviour
{
    // GameObject of the player
    public GameObject player;
    // Speed of the crossbow rotation
    public float speed = 5f;
    // offset in the X axis
    private float offsetY;
    // offset in the Y axis
    private float offsetX;

    void Start()
    {
        // We create the offsets
        offsetY = transform.position.y;
        offsetX = transform.position.x - 1.4f;
    }

    void Update()
    {
        // Apunta el axis Y (up) al personaje
        transform.up = player.transform.position - new Vector3(offsetX, offsetY, 0.0f);
    }

}
 