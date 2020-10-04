using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RespawnEvents : MonoBehaviour
{
    // Start is called before the first frame update

    public static RespawnEvents Respawn;
    private void Awake()
    {
        Respawn = this;
    }

    // Update is called once per frame
    public event Action Player;

    public void onRespawn()
    {
        if(Player != null)
        {
        Player();
        }
    }
    public event Action<Transform> change;

    public void changePos( Transform newRespawn)
    {
        if(change != null)
        {
            change(newRespawn);
        }
    }
}
