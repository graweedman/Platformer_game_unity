using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController controller;
    public Animator animator;
    public float speed = 4f;
    public float gravity = -9.18f;
    public float jumpHeight = 3f;
    public float airspeed = 0.5f;
    public float IdleTime = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    
    float defspeed;

    float counter;
    
    void Start()
    {
        defspeed = speed;
        counter = IdleTime;
    }

    // Update is called once per frame
    void Update()
    {
        bool standing = animator.GetBool("Stand");
        if(Input.GetButtonDown("Reset"))
        {
            Debug.Log("Reset");
            RespawnEvents.Respawn.onRespawn();
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -5f;
            speed = defspeed;
        }
        else
        {
            speed = defspeed * airspeed;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if(move.magnitude == 0)
        {
            if(!standing)
            {
                counter -= Time.deltaTime;
            }
            else
            {
                standing = false;
            }
        }
        else
        {
            counter = IdleTime;
        }
        if(counter<=0)
        {
            counter = IdleTime;
            standing = true;
        }
        animator.SetBool("Stand", standing);
        animator.SetFloat("Speed", move.magnitude);

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        

        velocity.y += gravity * Time.deltaTime;
    
        controller.Move(velocity * Time.deltaTime);
    }

    // private void OnRespawn()
    // {
    //     Debug.Log("respawning player", gameObject);
    //     Debug.Log("Respawned");
    //     Debug.Log("about to respawn the player (currently located at " + this.transform.position + ") at the position " + respawn.transform.position);
    //     Debug.Log(respawn.transform.position);
    //     playerBody.transform.position = respawn.transform.position;
    //     playerBody.transform.rotation = respawn.transform.rotation;
    //     Physics.SyncTransforms();
    //     Debug.Log("player has been respawned at " + playerBody.transform.position);
    // }
}
