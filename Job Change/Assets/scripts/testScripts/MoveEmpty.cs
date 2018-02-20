using UnityEngine;
using System.Collections;

public class MoveEmpty : MonoBehaviour {
    public float runSpeed;
    Rigidbody myRB;
    public bool facingRight;

    public bool grounded = false;
    Collider[] groundCollisions;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    
    void Start () {
        myRB = GetComponent<Rigidbody>();
        facingRight = true;
    }
	
	
	void Update () {
        //variable changer
        if (Input.GetKeyDown("1"))
        {
            runSpeed = 10;
            jumpHeight = 130;
        }
        if (Input.GetKeyDown("2"))
        {
            runSpeed = 5;
            jumpHeight = 100;
        }
        if (Input.GetKeyDown("3"))
        {
            runSpeed = 18;
            jumpHeight = 140;
        }
    }

    void FixedUpdate()
    {
        //movement code
        float move = Input.GetAxis("Horizontal");
        myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);


        //jumping code

        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myRB.AddForce(new Vector3(0, jumpHeight, 0));
        }

        groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if (groundCollisions.Length > 0) grounded = true;
        else grounded = false;
    }


}
