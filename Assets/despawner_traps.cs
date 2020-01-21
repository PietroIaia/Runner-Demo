using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawner_traps : MonoBehaviour
{
    public int no_despawn = 4;
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.name == "disable")
        {
            no_despawn = no_despawn - 1;
            if(no_despawn <= 0)
            {
                Destroy(col.transform.parent.gameObject);  // Obtiene el padre del gameObject que tiene el collider
            }
        }
    }
}
