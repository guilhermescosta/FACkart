using System;
using UnityEngine;

public class CarUserControl : MonoBehaviour
{
    //public CarController f_Car; // the car controller we want to use
    public Carro carro;
    //public RaceControl racecontrol;
    public int player;
    private float v;
    private float h;
    private bool handbrake;
    public GameObject cameraFrente;
    public GameObject CameraTras;
    private float tempodesvira;
    //public PauseMenu pause;

    private void Start()
    {
        tempodesvira = Time.time;
    }
    private void Update()
    {
        if (/*racecontrol.raceStart == true && */player == 1/* && pause.stoped == true*/)
        {
            if (Input.GetKey(KeyCode.W))
            {
                v = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                v = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                h = 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                h = -1;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                handbrake = true;
            }
            if (Input.GetKey(KeyCode.E)){
                if (CameraTras.activeSelf == false && cameraFrente==true) {
                    CameraTras.SetActive(true);
                    cameraFrente.SetActive(false);
                }

            }
            else {
                if (CameraTras.activeSelf == true && cameraFrente.activeSelf==false)
                {
                    CameraTras.SetActive(false);
                    cameraFrente.SetActive(true);
                }
            }
            if (Input.GetKey(KeyCode.R)) {
                if (tempodesvira < Time.time) {
                    carro.desvira();
                    tempodesvira = Time.time + 1;
                }
            }
        }
        /*if (racecontrol.raceStart == true && player == 2 && pause.stoped == true)
        {
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                v = 1;
            }
            if (Input.GetKey(KeyCode.Joystick1Button2))
            {
                v = -1;
            }

            h = Input.GetAxis("Horizontal");

                
            if (Input.GetKey(KeyCode.RightArrow))
            {
                h = 1;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                h = -1;
            }
                
            if (Input.GetKey(KeyCode.Joystick1Button1))
            {
                handbrake = 1;
            }
        }*/
        carro.mover(h, v, handbrake);

        /* Este codigo cuida da lanterna dos carros.Ele foi colocado aqui devido a menos
            erros e melhor otimiza��o.
        */
        /*if (v < 0)
            {
                f_Car.lanternaD.SetActive(true);
                f_Car.lanternaE.SetActive(true);
            }
            else
            {
                f_Car.lanternaD.SetActive(false);
                f_Car.lanternaE.SetActive(false);
            }
            */
        v = 0;
        h = 0;
        handbrake = false;
    }
}
