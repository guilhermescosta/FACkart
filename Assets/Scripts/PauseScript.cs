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
    public Button btnMainMenu;
    private ColorBlock colors;
    public RaceControl race;
    // Start is called before the first frame update
    void Start()
    {
        selec = -1;
        colors = btnContinue.colors;
        colors.highlightedColor = new Color32(255, 0 , 0, 255);
        btnContinue.colors = colors;
        btnQuit.colors = colors;
        btnReset.colors = colors;
        btnMainMenu.colors = colors;
    }

    // Update is called once per frame
    void Update()
    {
        if (pause.stoped==false) {
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                selec++;
                if (selec > 3)
                {
                    selec = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                selec--;
                if (selec < 0)
                {
                    selec = 3;
                }                
            }
            
            switch (selec) {
                case 0:
                    colors.normalColor = Color.red;
                    btnContinue.colors = colors;
                    colors.normalColor = Color.white;
                    btnReset.colors = colors;
                    btnQuit.colors = colors;
                    btnMainMenu.colors = colors;
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
                    btnMainMenu.colors = colors;
                    if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
                    {
                        race.RestartGame();
                    }
                    break;
                case 2:
                    colors = btnMainMenu.colors;
                    colors.normalColor = Color.red;
                    btnMainMenu.colors = colors;
                    colors.normalColor = Color.white;
                    btnQuit.colors = colors;
                    btnReset.colors = colors;
                    btnContinue.colors = colors;
                    if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
                    {
                        race.MainMenu();
                    }
                    break;
                case 3:
                    colors = btnContinue.colors;
                    colors.normalColor = Color.red;
                    btnQuit.colors = colors;
                    colors.normalColor = Color.white;
                    btnReset.colors = colors;
                    btnContinue.colors = colors;
                    btnMainMenu.colors = colors;
                    if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
                    {
                        pause.Quit();
                    }
                    break;
            }
        }
    }
}
