using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    // Start is called before the first frame update
    
    bool works = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            works = true;
            Debug.Log(works);
            RespawnEvents.Respawn.onRespawn();
        }
    }
    
}
