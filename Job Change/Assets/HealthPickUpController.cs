using UnityEngine;
using System.Collections;

public class HealthPickUpController : MonoBehaviour {

    public float healthAmount;
    public GameObject controller;
    public AudioClip healthPickUpSound;
    public float volume;

    void Start () {
	
	}
	
	
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            controller.GetComponent<playerHealth>().addHealth(healthAmount);
            Destroy(transform.root.gameObject);
            AudioSource.PlayClipAtPoint(healthPickUpSound, transform.position, volume);
        }
    }
}
