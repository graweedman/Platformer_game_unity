using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform respawn;
    void Start()
    {
        RespawnEvents.Respawn.Player += OnRespawn;
    }

    // Update is called once per frame
    private void OnRespawn()
    {
        Debug.Log("respawning player", gameObject);
        Debug.Log("Respawned");
        Debug.Log("about to respawn the player (currently located at " + this.transform.position + ") at the position " + respawn.transform.position);
        Debug.Log(respawn.position);
        this.transform.position = respawn.position;
        this.transform.rotation = respawn.rotation;
        Physics.SyncTransforms();
        Debug.Log("player has been respawned at " + this.transform.position);
    }
}
