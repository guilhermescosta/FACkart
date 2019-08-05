using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceControl : MonoBehaviour {

    public bool raceStart;
    public Image goLight;
    public float goTimer;

    public Text txtTempoLargada;
    private float tempoLargada;
    public int totalLaps;

    private int qtdPlayer;
    public GameObject playersolo;
    public GameObject playerdupla1;
    public GameObject playerdupla2;


    public Text txtvelocidadeplayer1;
    public Text txtvelocidadeplayer2;
    public Carro carrosolo;
    public Carro carrodupla1;
    public Carro carrodupla2;
    private bool dupla;


	// Use this for initialization
	void Start () {
        qtdPlayer = PlayerPrefs.GetInt("qtdplayer");
        raceStart = false;
        if (qtdPlayer == 1){
            playersolo.SetActive(true);
            playerdupla1.SetActive(false);
            playerdupla2.SetActive(false);
            dupla = false;
            txtvelocidadeplayer2.enabled=false;
        } else if (qtdPlayer==2){
            playersolo.SetActive(false);
            playerdupla1.SetActive(true);
            playerdupla2.SetActive(true);
            dupla = true;
        }
        tempoLargada=3;
	}
    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
	// Update is called once per frame
	void FixedUpdate () {
        if (dupla == false){
            txtvelocidadeplayer1.text=carrosolo.velocidadePassar.ToString("f0");
        } else if (dupla == true){
            txtvelocidadeplayer1.text=carrodupla1.velocidadePassar.ToString("f0");
            txtvelocidadeplayer2.text=carrodupla2.velocidadePassar.ToString("f0");
        }
        if (tempoLargada>0){
            tempoLargada-=Time.deltaTime;
        }
        txtTempoLargada.text=tempoLargada.ToString("f0");
        goTimer += Time.deltaTime;

        if (raceStart == false)
        {
            
            if (goTimer > 3  && goTimer <4)
            {
                goLight.color = new Color(0, 100, 0);
                raceStart = true; 
            }
             
            
        }

        if (goTimer > 4.5f)
        {
            txtTempoLargada.enabled = false;
            goLight.enabled = false;
        }
    }
    public void RestartGame() {
        SceneManager.LoadScene(this.gameObject.scene.buildIndex);
    }
}
