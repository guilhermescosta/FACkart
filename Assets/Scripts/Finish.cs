using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Ck1;
    public bool Ck2;
    public bool Ck3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PassCheck(int checkVol)
    {
        if (checkVol==1){
            Ck1=true;
        }
        if (checkVol==2){
            Ck2=true;
        }
        if (checkVol==3){
            Ck3=true;
        }
    }
}
