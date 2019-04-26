using System;
using UnityEngine;


namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {

        public float brakeTorque;
        public CarController f_Car; // the car controller we want to use
        public RaceControl racecontrol;
        public int player;
        private float v;
        private float h;
        private float handbrake;

        private void FixedUpdate()
        {
            if (racecontrol.raceStart == true && player == 1)
            {
                // pass the input to the car!
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
                    handbrake = 1;
                }
            }
            if (racecontrol.raceStart == true && player == 2)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    v = 1;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    v = -1;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    h = 1;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    h = -1;
                }
                if (Input.GetKey(KeyCode.Keypad0))
                {
                    handbrake = 1;
                }
            }
                f_Car.Move(h, v, v, handbrake);
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
                v = 0;
                h = 0;
                handbrake = 0;

            }
    }
}
