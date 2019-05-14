using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceControl : MonoBehaviour {

    public bool raceStart;
    public Image goLight;
    public float goTimer;

    public int totalLaps;

	// Use this for initialization
	void Start () {
        raceStart = false;
	}
    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
	// Update is called once per frame
	void Update () {
        goTimer += Time.deltaTime;

        if (raceStart == false)
        {
            
            if (goTimer > 3  && goTimer <4)
            {
                goLight.color = new Color(0, 100, 0);
                raceStart = true; 
            }
             
            
        }

        if (goTimer > 6)
        {
            goLight.enabled = false;
        }
    }
    public void RestartGame() {
        SceneManager.LoadScene(this.gameObject.scene.buildIndex);
    }
}
