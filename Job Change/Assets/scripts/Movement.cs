using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float runSpeed;

    Rigidbody myRB;

    //jumping

    bool grounded = false;
    Collider[] groundCollisions;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

  

    void Start () {
        myRB = GetComponent<Rigidbody>();
    }
	
	void Update () {
        }

    void FixedUpdate()
    {
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
