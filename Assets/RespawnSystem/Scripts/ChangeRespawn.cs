using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRespawn : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform newPosition;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            RespawnEvents.Respawn.changePos(newPosition);
        }
    }
}
