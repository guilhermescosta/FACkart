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
 
    public GameObject playerdupla1;
    public GameObject playerdupla2;


    public Text txtvelocidadeplayer1;
    public Text txtvelocidadeplayer2;
   
    public Carro carrodupla1;
    public Carro carrodupla2;

    public Text txtPosPlayer1;
    public Text txtPosPlayer2;

    private int check1;
    private int check2;
    public VerPrimeiro[] Verficadores;
    // Use this for initialization
    void Start () {
        raceStart = false;
        
        tempoLargada=3;
	}
    public void ResetaVerificadores(bool v) {
        if (v == true)
        {
            foreach (VerPrimeiro verficador in Verficadores)
            {
                verficador.Reseta1();
            }
        }
        else if (v == false) {
            foreach (VerPrimeiro verficador in Verficadores)
            {
                verficador.Reseta2();
            }
        }
    }
    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
    public void playerUmFirst() {
        check1++;
    }
    public void playerDoisFisrt() {
        check2++;
    }
	// Update is called once per frame
	void FixedUpdate () {
        
        txtvelocidadeplayer1.text=carrodupla1.velocidadePassar.ToString("f0");
        txtvelocidadeplayer2.text=carrodupla2.velocidadePassar.ToString("f0");
        if (tempoLargada>0){
            tempoLargada-=Time.deltaTime;
        }
        if (check1 >= check2)
        {
            txtPosPlayer1.text = "1/2";
            txtPosPlayer2.text = "2/2";
        }
        else if (check2 > check1) {
            txtPosPlayer1.text = "2/2";
            txtPosPlayer2.text = "1/2";
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
