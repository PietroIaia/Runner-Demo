using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machete_move : MonoBehaviour
{
    // Speed of machete 
    public int speed;
    // Variable to keep track of how much time the object is active
    private int time;
    // Start Position of Machete
    private Vector3 startPosition = new Vector3(0, 0, 31);


    void Update()
    {
        // The machete moves
        transform.eulerAngles = transform.eulerAngles + Vector3.forward * (-speed);
        time = time + 1;

        // When the desired position is reached, we reset the rotation and deactivate the object
        if(time >= 8){
            time = 0;
            transform.eulerAngles = startPosition;
            gameObject.SetActive(false);
        }
    }
}
