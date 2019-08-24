using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public CarRaceStats _car;
    public int maxVoltas;
    public Text txtVencedor;
    public GameObject panel;
    public RaceControl controlador;

    //public Finish Fin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //Fin.PassCheck(check);      
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "CarColl"){
            _car = other.GetComponent<CarRaceStats>();
            if (this.gameObject.name == "checkpoint_1"){
                _car.trueCheckP1();
            }
            if (this.gameObject.name == "checkpoint_2"){
                _car.trueCheckP2();
            }
            if (this.gameObject.name == "checkpoint_3"){
                _car.trueCheckP3();
            }

            if (this.gameObject.name == "finishLine"){
                _car.incrementoVoltas();
                if (other.gameObject.name == "Player_1")
                {
                    controlador.ResetaVerificadores(true);
                }
                else if (other.gameObject.name == "Player_2")
                {
                    controlador.ResetaVerificadores(false);
                }
                if (_car.voltas == maxVoltas){
                    Debug.Log(other.gameObject.name);
                    Debug.Log("Venceu a corrida");
                    panel.SetActive(true);
                    txtVencedor.text = other.gameObject.name + " venceu a corrida!";

                    // #######################################################
                    // ## Colocar aqui o codigo da condição de vitoria!!!!! ##
                    // #######################################################
                }
            }
        }
    }

}
