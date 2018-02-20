using UnityEngine;
using System.Collections;

public class meleeScript : MonoBehaviour {

    public float damage;
    public float knockback;
    public float knockBackRadius;
    public float meleeRate;

    float nextMelee;

    Animator myAnim;
    playerController myPC;

    int shootableMask;
	
	void Start () {
        shootableMask = LayerMask.GetMask("Shootable");
        myAnim = transform.GetComponentInParent<Animator>();
        myPC = transform.GetComponentInParent<playerController>();
        nextMelee = 0f;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy" || other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            enemyHealth theEnemyHealth = other.GetComponent<enemyHealth>();

            if (theEnemyHealth != null)
            {
                theEnemyHealth.addDamage(damage);
            }
        }
    }
}
