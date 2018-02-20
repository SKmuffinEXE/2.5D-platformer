using UnityEngine;
using System.Collections;

public class attackStart : MonoBehaviour {

    public GameObject attack;
    public Transform attackPlacement;

    public float damage;
    public float knockback;
    public float knockBackRadius;
    public float meleeRate;
    AudioSource swing;

    float nextMelee;

    Animator myAnim;
    playerController myPC;

    int shootableMask;

    // Use this for initialization
    void Start () {
        shootableMask = LayerMask.GetMask("Shootable");
        myAnim = transform.GetComponentInParent<Animator>();
        myPC = transform.GetComponentInParent<playerController>();
        nextMelee = 0f;
        swing = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        float melee = Input.GetAxis("Fire1");
        if (melee > 0 && nextMelee < Time.time)
        {
            myAnim.SetTrigger("swordSwing");
            nextMelee = Time.time + meleeRate;

            //damage
            Collider[] attacked = Physics.OverlapSphere(transform.position, knockBackRadius, shootableMask);
            Instantiate(attack, attackPlacement.position, attackPlacement.rotation);
            swing.Play();
        }
    }
}
