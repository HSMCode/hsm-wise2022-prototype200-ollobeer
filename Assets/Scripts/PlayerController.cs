using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables for Movement
    public float forwardInput;
    public float horizontalInput;
    public float speed; //player movement speed

    
    //Variables for Mouse Position/Movement
    public float camSens = 0.25f; //How sensitive the rotation is
    private Vector3 lastMouse = new Vector3(700, 255, 255); //kind of in the middle of the screen, rather than at the top (play)


    //Variables for Jump
    public bool isOnGround;
    public bool isJumping;
    public float force;
    public float maxJumpHeight;
    private float stop;
    private float lastGrounded;


    public Rigidbody RB;

    void Start()
    {
        //Get Rigidbody from player
        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Player Movement
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed); //forward movement
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed); //horizontal movement

        //mouse rotation controls player rotation
        //stolen from the internet, not 100% sure how it works :)
        lastMouse = Input.mousePosition - lastMouse;  //update mouse position
        lastMouse = new Vector3(0, lastMouse.x * camSens, 0 );  //only horizontal
        lastMouse = new Vector3(0, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse =  Input.mousePosition;


        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            isJumping = true;
        }
        
        //stop jumping, if player lets go of space or reaches the maxJumpheight
        if (Input.GetKeyUp(KeyCode.Space) || stop < 0)
        {
            isJumping = false;
        }

        //calculate "stop" based on player y position and maxJumpHeight
        //lastGrounded = y position the last time th player was grounded
        stop = maxJumpHeight - this.gameObject.transform.position.y - lastGrounded;
    }

    //Jump Force
    void FixedUpdate()
    {
        if(isJumping)
        {
            RB.AddForce(Vector3.up * force, ForceMode.Force);
        }
    }

    //Check for Grounded
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            
            lastGrounded = this.gameObject.transform.position.y; //re-calculate lastGrounded
        }

    }
}
