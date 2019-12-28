using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_traps : MonoBehaviour
{
    public GameObject rain;
    public GameObject crossbow;
    public GameObject enemy;
    public GameObject empty_space;
    private System.Random random;
    int oldi;
    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        oldi = -1;
    }

    // Update is called once per frame

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "disable")
        {
            // If the last object instantiated was a empty_space, the next space cant be an empty_sapce.
            int i = random.Next(0, 4);
            while(true)
            {
                if(oldi == 3 && oldi == i)
                {
                    i = random.Next(0, 4);  
                }
                else
                {
                    break;
                }
            }

            if(i == 0)
            {
                if(oldi == 1)
                {
                    Instantiate(rain, gameObject.transform.position + new Vector3(5.97f, 6.75f, 0.0f), Quaternion.identity); 
                }
                else
                {
                    Instantiate(rain, gameObject.transform.position + new Vector3(1.97f, 6.75f, 0.0f), Quaternion.identity); 
                }
            }
            else if(i == 1)
            {
                Instantiate(crossbow, gameObject.transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity); 
            }
            else if(i == 2)
            {
                Instantiate(enemy, gameObject.transform.position + new Vector3(0.0f, -1.56f, 0.0f), Quaternion.identity); 
            }
            else if(i == 3)
            {
                Instantiate(empty_space, gameObject.transform.position + new Vector3(1.0f, -1.56f, 0.0f), Quaternion.identity); 
            }

            oldi = i;
        }
    }
}
