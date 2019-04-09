using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour {

    // car 
    public Rigidbody rb;
    public float maxSpeed;

    public float backSpeed;
    public float maxSpeedReal;
    public float sandSpeed;
    public float speed;
    
    public float Aceleration;

    public int playerNumber;   // 1 player 

    // race
    public bool isStart;
    public int currentLap;
    public int totalLaps;
    public float timeLap;
    public RaceControl _control;
    public bool checkPoint;

    // UI

    public Text laps;
    public GameObject resultPanel;
    public Text totalTimeText;




    // Use this for initialization
    void Start () {
        currentLap = 1;
        isStart = false;
        laps.text = currentLap.ToString() + " / " + _control.totalLaps.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        
        if (isStart == false)
        {

            if (_control.raceStart == true) {
                isStart = true;
               
            }
        }

        else
        {
           if (playerNumber == 1){
            transform.Translate(speed, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                if (speed <= maxSpeed)
                {
                    speed += Aceleration;
                    //rb.AddForce(Vector3.forward *-200f);
                }

                //rb.AddForce(Vector3.right *200f);

            }
            else if (speed > 0)
            {
                speed -= .01f;
            }



            if (Input.GetKey(KeyCode.S))
            {
                //if (speed > 0)
                //{
                    speed -= Aceleration;
                //}

                transform.Translate(-1, 0, 0);
                //rb.AddForce(Vector3.left * 50f);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -1, 0);
                //rb.AddForce(Vector3.left *-200f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 1, 0);
                //rb.AddForce(Vector3.right *-200f);
            }



           }
           if (playerNumber == 2){
            transform.Translate(speed, 0, 0);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (speed <= maxSpeed)
                {
                    speed += Aceleration;
                }

                //rb.AddForce(Vector3.right *200f);

            }
            else if (speed > 0)
            {
                speed -= .01f;
            }



            if (Input.GetKey(KeyCode.DownArrow))
            {
                //if (speed > 0)
                //{
                    speed -= Aceleration;
                //}

                //transform.Translate(-1, 0, 0);
                //rb.AddForce(Vector3.left * 50f);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, -1, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 1, 0);
            }



           }
            

            // out of the road !
            if (speed > maxSpeed) {
                speed = maxSpeed;
            }
            if (speed > maxSpeed) {
                speed = maxSpeed;
            }
            if (speed < backSpeed){
                speed = backSpeed;
            }
        }

        if (_control.raceStart == true)
        {
            timeLap += Time.deltaTime;
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("checkpoint")) {
            checkPoint = true;
        }

        if (other.CompareTag("finishline") && checkPoint == true)
        {
            currentLap += 1;
            if (currentLap > _control.totalLaps) {
                _control.raceStart = false;
                resultPanel.SetActive(true);
                totalTimeText.text = "total time: " + timeLap.ToString();
                

            }
            else
            laps.text = currentLap.ToString() + " / " + _control.totalLaps.ToString();
        } 


        if (other.CompareTag("Sand"))
        {
          
            maxSpeed = sandSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sand"))
        {
            maxSpeed = maxSpeedReal;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.CompareTag("Collisor") && speed > 1) { 
            speed = -1;
        }*/
    }
}


