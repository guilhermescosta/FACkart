using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public CarRaceStats _car;
    public int maxVoltas;
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
                if (_car.voltas == maxVoltas){
                    Debug.Log(other.gameObject.name);
                    Debug.Log("Venceu a corrida");
                    // #######################################################
                    // ## Colocar aqui o codigo da condição de vitoria!!!!! ##
                    // #######################################################
                }
            }
        }
    }

}
