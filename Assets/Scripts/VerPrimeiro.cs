using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerPrimeiro : MonoBehaviour
{
    public bool Pass1;
    public bool Pass2;
    public void Reseta1() {
        Pass1 = false;
    }
    public void Reseta2() {
        Pass2 = false;
    }
    public RaceControl Controlador;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player_1")
        {
            Pass1 = true;
            Controlador.playerUmFirst();
        }
        else if (col.gameObject.name == "Player_2")
        {
            Pass2 = true;
            Controlador.playerDoisFisrt();
        }
    }
}
