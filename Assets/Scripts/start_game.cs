using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                  // Added Manually, Needed for variable type 'Image'

public class start_game : MonoBehaviour
{
    public Image Number3;
    public Image Number2;
    public Image Number1;
    public Image[] container;

    // Start is called before the first frame update
    void Start()
    {
       Time.timeScale = 0; 
       container = new Image[3];
       container[0] = Number1;
       container[1] = Number2;
       container[2] = Number3;
       StartCoroutine(CountDown());
    }

    public IEnumerator CountDown()
    {
        int i = 3;
        while(true)
        {
            i -= 1;
            if(i == -1)
            {
                container[0].GetComponent<Image>().enabled = false;
                break;
            }

            if(i != 2) container[i+1].GetComponent<Image>().enabled = false;
            container[i].GetComponent<Image>().enabled = true;

            yield return new WaitForSecondsRealtime(1);
        }

        Time.timeScale = 1;
    }
}
