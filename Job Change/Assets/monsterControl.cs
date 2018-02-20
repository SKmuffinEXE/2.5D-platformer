using UnityEngine;
using System.Collections;

public class monsterControl : MonoBehaviour {

    public GameObject flipModel;
    public AudioClip[] idleSounds;
    public float idleSoundTime;
    AudioSource enemyMovementAS;
    float nextIdleSound = 0f;

    public float detectionTime;
    float startRun;
    bool firstDetection;

    //movement option
    public float movementSpeed;
    public float walkSpeed; //we don't have one
    public bool facingRight = true;
    public float moveSpeed;
    public bool moving; //running

    Rigidbody myRB;
    Animator myAnim;
    Transform detectedPlayer;
    public bool detected;

	// Use this for initialization
	void Start () {
        myRB = GetComponentInParent<Rigidbody>();
        myAnim = GetComponentInParent<Animator>();
        enemyMovementAS = GetComponent<AudioSource>();

        moving = false;
        detected = false;
        firstDetection = false;
        //moveSpeed = movementSpeed;

        if(Random.Range(0, 10) > 5)
        {
            Flip();
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (detected)
        {
            if (detectedPlayer.position.x > transform.position.x && facingRight) Flip();
            else if (detectedPlayer.position.x < transform.position.x && !facingRight) Flip();

            /*if (!firstDetection)
            {
                startRun = Time.time + detectionTime;
                firstDetection = true;
            } */
        }
        if (detected && !facingRight) myRB.velocity = new Vector3((moveSpeed), myRB.velocity.y, 0);
        else if (detected && facingRight) myRB.velocity = new Vector3((moveSpeed * -1), myRB.velocity.y, 0);

        /*if(!moving && detected)
        {
            if(startRun<Time.time)
            {
                moveSpeed = movementSpeed;
                //myAnim.SetTrigger("run");
                moving = true;
            }
        } */

        //sounds
        if(!moving)
        {
            if(Random.Range(0,10) > 5 && nextIdleSound < Time.time)
            {
                AudioClip tempClip = idleSounds[Random.Range(0, idleSounds.Length)];
                enemyMovementAS.clip = tempClip;
                enemyMovementAS.Play();
                nextIdleSound = idleSoundTime + Time.time;

            }
        }  

	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player")
        {
            moveSpeed = movementSpeed;
            moving = true;
            detected = true;
            detectedPlayer = other.transform;
            myAnim.SetBool("detected", detected);
            //if (detectedPlayer.position.x < transform.position.x && facingRight) Flip();
            //else if (detectedPlayer.position.x > transform.position.x && !facingRight) Flip();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            moveSpeed = 0;
            moving = false;
            detected = false;
            firstDetection = false;
            myAnim.SetBool("detected", detected);
            /*if (moving)
            {
                //myAnim.SetTrigger("run");
                moving = false;
            } */
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = flipModel.transform.localScale;
        theScale.z *= -1;
        flipModel.transform.localScale = theScale;
    }

}
