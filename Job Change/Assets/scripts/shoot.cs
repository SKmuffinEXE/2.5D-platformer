using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

    //public float moveSpeed;
    //private float maxSpeed = 5f;
    //private Vector3 input;


    public float timeBetweenBullets = 0.6f;
    float nextBullet;
    public GameObject projectile;
    public Animator attackAnim;
    bool attacking = false;

    AudioSource magicMissileAS;

    void Awake () {
        nextBullet = 0f;
        attackAnim = GetComponentInParent<Animator>();
        magicMissileAS = GetComponent<AudioSource>();
    }
	
	void Update () {

        playerController myPlayer = transform.GetComponentInParent<playerController>();

        if(Input.GetAxisRaw("Fire1")>0 && nextBullet<Time.time) {
            nextBullet = Time.time + timeBetweenBullets;

            Vector3 rot;
            //attackAnim.SetBool("basic", attacking);
            //attacking = true;
            if (myPlayer.GetFacing() == 1f)
            {
               //yield return new WaitForSeconds(5);
                rot = new Vector3(0, 90, 0);
                
                
            }
            else
            {
                rot = new Vector3(0, -90, 0);
            }

            attackAnim.SetTrigger("magic");

            Instantiate(projectile, transform.position, Quaternion.Euler(rot));
            magicMissileAS.Play();
                }
    }
}




