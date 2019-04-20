using System;
using UnityEngine;


namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {

        public float brakeTorque;
        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = Input.GetKey(KeyCode.Space) ? brakeTorque * 10 : 0; ;
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
            
#endif

            /* Este codigo cuida da lanterna dos carros.Ele foi colocado aqui devido a menos
            erros e melhor otimização.
            */
            if (v < 0)
            {
                m_Car.lanternaD.SetActive(true);
                m_Car.lanternaE.SetActive(true);
            }
            else
            {
                m_Car.lanternaD.SetActive(false);
                m_Car.lanternaE.SetActive(false);
            }
        }
    }
}
