using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public PauseMenu pause;
    private int selec = 0;
    public Button btnContinue;
    public Button btnReset;
    public Button btnQuit;
    private ColorBlock colors;
    public RaceControl race;
    // Start is called before the first frame update
    void Start()
    {
        selec = 0;
        colors = btnContinue.colors;
        colors.highlightedColor = new Color32(255, 0 , 0, 255);
        btnContinue.colors = colors;
        btnQuit.colors = colors;
        btnReset.colors = colors;
    }

    // Update is called once per frame
    void Update()
    {
        if (pause.stoped==false) {
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                selec++;
                if (selec > 2)
                {
                    selec = 0;
                }
                Debug.Log(selec);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                selec--;
                if (selec < 0)
                {
                    selec = 2;
                }
                Debug.Log(selec);
                
            }
            
            switch (selec) {
                case 0:
                    colors.normalColor = Color.red;
                    btnContinue.colors = colors;
                    colors.normalColor = Color.white;
                    btnReset.colors = colors;
                    btnQuit.colors = colors;
                    if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
                    {
                        pause.Unpause();
                    }
                    break;
                case 1:
                    
                    colors.normalColor = Color.red;
                    btnReset.colors = colors;
                    colors.normalColor = Color.white;
                    btnContinue.colors = colors;
                    btnQuit.colors = colors;
                    if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
                    {
                        race.RestartGame();
                    }
                    break;
                case 2:
                    colors = btnContinue.colors;
                    colors.normalColor = Color.red;
                    btnQuit.colors = colors;
                    colors.normalColor = Color.white;
                    btnReset.colors = colors;
                    btnContinue.colors = colors;
                    if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
                    {
                        pause.Quit();
                    }
                    break;
            }
        }
    }
}
