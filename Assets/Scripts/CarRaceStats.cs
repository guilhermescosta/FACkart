using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRaceStats : MonoBehaviour
{
    public int voltas;
    public bool checkP1;
    public bool checkP2;
    public bool checkP3;

    // Start is called before the first frame update
    void Start()
    {
        voltas = 0;
        checkP1 = false;
        checkP2 = false;
        checkP3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementoVoltas(){
        if (checkP1 && checkP2 && checkP3){
            voltas += 1;
            Debug.Log(voltas);
            checkP1 = false;
            checkP2 = false;
            checkP3 = false;
        }
    }

    public void trueCheckP1 () {
        if(checkP2 == false && checkP3 == false){
            checkP1 = true;
        } else {
            Debug.Log("Wrong Way! Trapaceiro!");
        }
    }

    public void trueCheckP2 () {
        if (checkP1 && checkP3 == false){
            checkP2 = true;
        } else {
            Debug.Log("Wrong Way! Trapaceiro!");
        }
    }

    public void trueCheckP3 () {
        if(checkP1 && checkP2){
            checkP3 = true;
        } else {
            Debug.Log("Wrong Way! Trapaceiro!");
        }
    }

}
