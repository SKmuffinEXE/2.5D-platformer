using UnityEngine;
using System.Collections;

public class crystalAttacks : MonoBehaviour {

    //attack
    public GameObject projectile;
    public float timeBetweenBullets;
    float nextBullet;
    Vector3 rot;

    //detection
    public GameObject flipModel;
    public GameObject fireRight;
    public GameObject fireLeft;
    Transform fireL;
    Transform fireR;
    public float detectionTime;
    Transform detectedPlayer;
    public bool detected;
    public bool facingRight = true;

    // Use this for initialization
    void Start () {
        nextBullet = 0f;
        detected = false;
        fireL = fireLeft.GetComponent<Transform>();
        fireR = fireRight.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        if (detected)
        {
            if (detectedPlayer.position.x < transform.position.x && facingRight)
            {
                Flip();
                rot = new Vector3(0, -90, 0);
            }
            else if (detectedPlayer.position.x > transform.position.x && !facingRight)
            {
                Flip();
                rot = new Vector3(0, 90, 0);
            }
        }

        if (detected && !facingRight && nextBullet < Time.time)
        {
            nextBullet = Time.time + timeBetweenBullets;
            Instantiate(projectile, fireL.position, Quaternion.Euler(rot));
        }
        else if (detected && facingRight && nextBullet < Time.time)
        {
            nextBullet = Time.time + timeBetweenBullets;
            Instantiate(projectile, fireR.position, Quaternion.Euler(rot));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            detected = true;
            detectedPlayer = other.transform;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            detected = false;
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
