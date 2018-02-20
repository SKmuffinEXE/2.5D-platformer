using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

    public float fullHealth;
    public float currentHealth;
    public GameObject playerDeathFX;

    //HUD
    public Slider playerHealthSlider;
    public GameObject endGameText;
    public restartGame switcher;

    AudioSource playerAS;
	
	void Start () {
        currentHealth = fullHealth;
        playerHealthSlider.maxValue = fullHealth;
        playerHealthSlider.value = currentHealth;

        playerAS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("q"))
        {
            currentHealth += 10;
        }

        if (Input.GetKeyDown("e"))
        {
            currentHealth -= 10;
        }

    }

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        playerAS.Play();
        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void addHealth(float health)
    {
        currentHealth += health;
        if (currentHealth > fullHealth) currentHealth = fullHealth;
        playerHealthSlider.value = currentHealth;
    }

    public void makeDead()
    {
        endGameText.SetActive(true);
        Instantiate(playerDeathFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        Destroy(gameObject);
        switcher.restartTheGame();
    }

}
