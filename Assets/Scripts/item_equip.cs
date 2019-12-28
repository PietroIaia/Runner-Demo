using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                  // Added Manually, Needed for variable type 'Image'

public class item_equip : MonoBehaviour
{

    [SerializeField]                  // Used when we want to show a private variable on the Inspector 
    // Image on UI
    private Image Image;
    // Key to darken the image
    public string s;
    // Keys to make the Image go back to normal
    public string s1;
    public string s2;


    void Update()
    {
        // Darken the image
        if(Input.GetKeyDown(s))
        {
            //                     (R,G,B,A)
            Image.color = new Color(0.4150943f, 0.4150943f, 0.4150943f, 1.00f);
        }
        
        // Make the Image go back to normal color
        if(Input.GetKeyDown(s1) || Input.GetKeyDown(s2))
        {
            Image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
