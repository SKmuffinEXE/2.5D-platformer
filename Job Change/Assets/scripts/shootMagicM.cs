﻿using UnityEngine;
using System.Collections;

public class shootMagicM : MonoBehaviour {

    public float damage;
    public float speed;

    Rigidbody myRB;

	// Use this for initialization
	void Start () {
        myRB = GetComponentInParent<Rigidbody>();

        if (transform.rotation.y > 0) myRB.AddForce(Vector3.right * speed, ForceMode.Impulse);
        else myRB.AddForce(Vector3.right * -speed, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy" || other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myRB.velocity = Vector3.zero;
            enemyHealth theEnemyHealth = other.GetComponent<enemyHealth>();

            if(theEnemyHealth != null)
            {
                theEnemyHealth.addDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
