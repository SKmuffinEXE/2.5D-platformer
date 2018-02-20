using UnityEngine;
using System.Collections;


public class switcher : MonoBehaviour {

    string character;

    public GameObject mage;
    public GameObject knight;
    public GameObject thief;
    

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("1"))
        {
            character = "mage";
            knight.SetActive(false);
            thief.SetActive(false);
            mage.SetActive(true);
            
        }
        if (Input.GetKeyDown("2"))
        {
            character = "knight";
            mage.SetActive(false);
            thief.SetActive(false);
            knight.SetActive(true);
        }
        if (Input.GetKeyDown("3"))
        {
            character = "thief";
            mage.SetActive(false);
            thief.SetActive(true);
            knight.SetActive(false);
        }

        //GameObject.Find(character).renderer.enabled = false;

    }
}
