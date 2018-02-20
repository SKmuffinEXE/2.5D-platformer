using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {

    public Transform monster;
    public float enemyMaxHealth;
    public float damageModifier;
    public GameObject damageParticles;
    public GameObject drop;
    public bool drops;
    public AudioClip deathSound;

    public float currentHealth;
    public Slider enemyHealthIndicator;
    AudioSource enemyAS;

	// Use this for initialization
	void Start () {
        currentHealth = enemyMaxHealth;
        enemyHealthIndicator.maxValue = enemyMaxHealth;
        enemyHealthIndicator.value = currentHealth;
        enemyAS = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addDamage(float damage)
    {
        enemyHealthIndicator.gameObject.SetActive(true);
        damage = damage * damageModifier;
        if (damage <= 0f) return;
        enemyAS.Play();
        currentHealth -= damage;
        enemyHealthIndicator.value = currentHealth;
        if (currentHealth <=0) makeDead();
    }

    public void damageFX(Vector3 point, Vector3 rotation )
    {
        Instantiate(damageParticles, point, Quaternion.Euler(rotation));
    }

    void makeDead()
    {
        //kill enemy
        AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.15f);
        Destroy(gameObject.transform.root.gameObject);
        if (drops) Instantiate(drop, monster.position, monster.rotation);
    }
}
