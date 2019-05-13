using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincial : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mCamera;
    
    void Start()
    {
        
    }
    public void StartGame(){
        SceneManager.LoadScene(1);
    }
    public void Quit() {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        mCamera.transform.Rotate(0,0.5f,0);
    }
}
