using UnityEngine;
using System.Collections;

public class enemyMM : MonoBehaviour {

    public float damage;
    public float damageRate;
    public float knockBack;
    public float speed;

    float nextDamage;

    bool playerInRange = false;

    Rigidbody myRB;
    GameObject thePlayer;
    public GameObject thePlayerController;
    playerHealth thePlayerHealth;

    // Use this for initialization
    void Start () {
        nextDamage = Time.time;
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        thePlayerController = GameObject.FindGameObjectWithTag("GameController");
        thePlayerHealth = thePlayerController.GetComponent<playerHealth>();

        myRB = GetComponentInParent<Rigidbody>();

        if (transform.rotation.y > 0) myRB.AddForce(Vector3.right * speed, ForceMode.Impulse);
        else myRB.AddForce(Vector3.right * -speed, ForceMode.Impulse);

    }
	
	// Update is called once per frame
	void Update () {
        if (playerInRange) Attack();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }

    void Attack()
    {
        if (nextDamage <= Time.time)
        {
            thePlayerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;
            pushBack(thePlayer.transform);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector3 pushDirection = new Vector3(0, (pushedObject.position.y - transform.position.y), 0).normalized;
        pushDirection *= knockBack;

        Rigidbody pushedRB = pushedObject.GetComponent<Rigidbody>();
        pushedRB.velocity = Vector3.zero;
        pushedRB.AddForce(pushDirection, ForceMode.Impulse);
    }
}
