using System;
using UnityEngine;


namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {

        public float brakeTorque;
        public CarController f_Car; // the car controller we want to use
        public CarController s_Car; // Player 2
        public RaceControl racecontrol;

        private float v;
        private float h;
        private float l;
        private float o;


        private void Awake()
        {
            // get the car controller
            
                f_Car = GameObject.FindGameObjectWithTag("Player1").GetComponent<CarController>();
            
                s_Car = GameObject.FindGameObjectWithTag("Player2").GetComponent<CarController>();
            
        }


        private void FixedUpdate()
        {
            if (racecontrol.raceStart == true){
            // pass the input to the car!
                h = Input.GetAxis("mPlayer1");
                v = Input.GetAxis("vPlayer1");
    #if !MOBILE_INPUT
                float handbrake = Input.GetKey(KeyCode.Space) ? brakeTorque * 10 : 0; ;
                f_Car.Move(h, v, v, handbrake);
    #else
                f_Car.Move(h, v, v, 0f);
                
    #endif
            }
            
            if (racecontrol.raceStart == true){
                    // pass the input to the car!
                o = Input.GetAxis("vPlayer2");
                l = Input.GetAxis("mPlayer2");
    #if !MOBILE_INPUT
                float handbroke = Input.GetKey(KeyCode.Space) ? brakeTorque * 10 : 0; ;
                s_Car.Move(l, o, o, handbroke);
    #else
                s_Car.Move(l, o, o, 0f);
                
    #endif
            }
            

            /* Este codigo cuida da lanterna dos carros.Ele foi colocado aqui devido a menos
            erros e melhor otimiza��o.
            */
            if (v < 0)
            {
                f_Car.lanternaD.SetActive(true);
                f_Car.lanternaE.SetActive(true);
            }
            else
            {
                f_Car.lanternaD.SetActive(false);
                f_Car.lanternaE.SetActive(false);
            }
            if (o < 0)
            {
                s_Car.lanternaD.SetActive(true);
                s_Car.lanternaE.SetActive(true);
            }
            else
            {
                s_Car.lanternaD.SetActive(false);
                s_Car.lanternaE.SetActive(false);
            }
        }
    }
}
