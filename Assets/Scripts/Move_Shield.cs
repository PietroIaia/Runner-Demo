using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Shield : MonoBehaviour
{
    // Speed of Shield
    public float speed = 5f;


    void Update()
    {   
        // This will make the object rotate around the player based on where the mouse is located
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
