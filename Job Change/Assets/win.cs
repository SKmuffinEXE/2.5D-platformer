using UnityEngine;
using System.Collections;

public class win : MonoBehaviour {

    public GameObject winText;
    bool playerWin;
    public restartGame switcher;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(playerWin == true)
        {
            winText.SetActive(true);
            
        }
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerWin = true;
            switcher.restartTheGame();
        }
    }
}
