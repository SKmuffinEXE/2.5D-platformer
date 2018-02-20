using UnityEngine;
using System.Collections;

public class shootBullet : MonoBehaviour {

    public float range = 10f;
    public float damage = 5f;

    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    LineRenderer gunline;

	// Use this for initialization
	void Awake () {
        shootableMask = LayerMask.GetMask("Shootable");
        gunline = GetComponent<LineRenderer>();

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        gunline.SetPosition(0, transform.position);

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            //hit an enemy goes here
            gunline.SetPosition(1, shootHit.point);
        }
        else gunline.SetPosition(1, shootRay.origin + shootRay.direction * range);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
