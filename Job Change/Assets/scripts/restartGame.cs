using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour {

    public float restartTime;
    public bool resetNow = false;
    float resetTime;

	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (resetNow == true && resetTime <= Time.time)
        {
            SceneManager.LoadScene("main", LoadSceneMode.Single);
            //Application.LoadLevel(Application.loadedLevel);
            resetNow = false;
        }
    }

    public void restartTheGame()
    {
        resetNow = true;
        resetTime = restartTime + Time.time;
    }
}
