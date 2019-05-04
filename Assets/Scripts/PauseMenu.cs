using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Rigidbody carro1;
    public Rigidbody carro2;
    public GameObject menuPause;
    private Vector3 temp1;
    private Vector3 temp2;
    public WheelCollider[] WheelsCarro1;
    public WheelCollider[] WheelsCarro2;
    
    public RaceControl racecontrol;

    public bool stoped;
    // Start is called before the first frame update
    void Start()
    {
        stoped = true;
    }
    public void Unpause() {
        carro1.velocity = temp1;
        carro2.velocity = temp2;
        menuPause.SetActive(false);
        stoped = true;
    }
    public void Quit() {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        if (racecontrol.raceStart == true){
            if (stoped == true && Input.GetKeyDown(KeyCode.Escape)) {
                menuPause.SetActive(true);
                temp1 = carro1.velocity;
                carro1.velocity = Vector3.zero;
                for (int i = 0; i < 4; i++)
                {
                    WheelsCarro1[i].motorTorque = 0;
                    WheelsCarro1[i].brakeTorque = float.MaxValue;
                }
                temp2 = carro2.velocity;
                carro2.velocity = Vector3.zero;
                for (int i = 0; i < 4; i++)
                {
                    WheelsCarro2[i].motorTorque = 0;
                    WheelsCarro2[i].brakeTorque = float.MaxValue;
                }
                stoped = false;
            }
            /*Menu averto e jogo pausado
             * if (stoped == false && Input.GetKeyDown(KeyCode.Space)) {
                carro1.velocity = temp1;
                carro2.velocity = temp2;
                menuPause.SetActive(false);
                stoped = true;
            }*/
        }
    }
}
