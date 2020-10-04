using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovementRigid : MonoBehaviour
{
    [SerializeField]
    private Rigidbody player;
    public Transform Camera;
    public Animator animator;
    public float defspeed = 12f;
    public float maxspeed = 20f;

    public float jumpsPower = 30f;
    public float airspeed = 0.7f;

    public float extraGravity = 45;

    float bodyRotationX;

    float camRotationY;
    Vector3 directionIntentX;
    Vector3 directionIntentY;

    bool isGrounded;
    float speed;
    // Update is called once per frame
    void Start()
    {
        speed = defspeed;
    }
    void Update()
    {
        Movement();
        //ExtraGravity();
        GroundCheck();
        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if(Input.GetButtonDown("Reset"))
        {
            RespawnEvents.Respawn.onRespawn();
        }
    }
    void Movement()
    {
        directionIntentX = Camera.right;
        directionIntentX.y = 0;
        directionIntentX.Normalize();

        directionIntentY = Camera.forward;
        directionIntentY.y = 0;
        directionIntentY.Normalize();
        if(isGrounded)
        {
            //Debug.Log("Grounded");
            speed = defspeed;
        }
        else
        {
            //Debug.Log("Not Grounded");
            speed = defspeed * airspeed;
        }
        player.velocity = directionIntentY * Input.GetAxis("Vertical") * speed + directionIntentX * Input.GetAxis("Horizontal") * speed + Vector3.up * player.velocity.y;

        player.velocity = Vector3.ClampMagnitude(player.velocity, maxspeed);
        
    }
    void ExtraGravity()
    {
        player.AddForce(Vector3.down * extraGravity);
    }

    void GroundCheck()
    {
        RaycastHit groundHit;
        isGrounded = Physics.Raycast(transform.position, -transform.up, out groundHit, 1.25f);
    }
    void Jump()
    {
        player.AddForce(Vector3.up * jumpsPower, ForceMode.Impulse);
    }
}
