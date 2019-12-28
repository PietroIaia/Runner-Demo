using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockY : MonoBehaviour
{
    // Y position of camera
    private float y_position = 0;


    void Update()
    {
        // The camera is locked on Y axis
        this.transform.position = new Vector3(transform.position.x, y_position, transform.position.z);
    }
}
