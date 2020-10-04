using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RespawnEvents.Respawn.change += UpdatePos;
    }

    // Update is called once per frame
    void UpdatePos(Transform newRespawn)
    {
        Debug.Log("Respawn Moved");
        this.transform.position = newRespawn.position;
        this.transform.rotation = newRespawn.rotation;
        Physics.SyncTransforms();
    }
}
