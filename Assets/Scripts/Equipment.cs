using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    // Variable to keep track wich item is being used
    public int onUse = 0;
    // GameObject of Machete
    public GameObject machete;
    // GameObject of Umbrella
    public GameObject umbrella;
    // GameObject of Shield
    public GameObject shield;

    void Update()
    {
        // If we press q, it equips the Machete
        if(Input.GetKeyDown("q"))
            onUse = 1;
        // If we press w, it equips the Shield
        if(Input.GetKeyDown("w"))
            onUse = 2;
        // If we press e, it equips the Umbrella
        if(Input.GetKeyDown("e"))
            onUse = 3;


        // Machete is equipped
        if(onUse == 1)
        {
            // Deactivate other equipment if active
            umbrella.SetActive(false);
            shield.SetActive(false);

            // If we left click, the Machete is used
            if(Input.GetMouseButtonDown(0))
            {
                machete.SetActive(true);
            }
        }
        // Shield is equipped
        if(onUse == 2)
        {
            // Deactivate other equipment if active
            umbrella.SetActive(false);
            machete.SetActive(false);

            // If we left click, the Shield is used
            if(Input.GetMouseButton(0))
            {
                shield.SetActive(true);
            }
            // If we stop left clicking, the Shield is no longer used
            if(Input.GetMouseButtonUp(0))
            {
                shield.SetActive(false);
            }
        }
        // Umbrella is equipped
        if(onUse == 3)
        {
            // Deactivate other equipment if active
            shield.SetActive(false);
            machete.SetActive(false);
            
            // If we left click, the Umbrella is used
            if(Input.GetMouseButton(0))
            {
                umbrella.SetActive(true);
            }
            // If we stop left clicking, the Umbrella is no longer used
            if(Input.GetMouseButtonUp(0))
            {
                umbrella.SetActive(false);
            }
        }
    }
}
