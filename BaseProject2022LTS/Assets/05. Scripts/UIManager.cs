using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class UIManager : MonoBehaviour
{

    public Canvas canvasPause, canvasUI,canvasStart;
    public static float min, sec, time;
    public Text textTimer,textStart;
    public GameObject resumeB,backControlsButton,OptionsButton, canvasPanelControls, canvasPanelOptions;//3ds con la animacion de ganar
    public EventSystem ev;
    public AudioMixer audioMixer;

    void Start()
    {
        canvasPause.GetComponent<Canvas>().enabled = false;//We disable the canvas for the pause, just in case.
        canvasUI.GetComponent<Canvas>().enabled = false;
        time = 60;//We set the time for the game.
    }

    public void controlsPanel()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(backControlsButton);
    }

    public void optionsPanel()
    {
        ev.SetSelectedGameObject(OptionsButton);
    }
   
    void Update()
    {
        //Boton de pausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvasPause.GetComponent<Canvas>().enabled = !canvasPause.GetComponent<Canvas>().enabled;//We enable the canvas pause.
            if (Time.timeScale == 1)
            {    //If the time speed is 1
                Time.timeScale = 0;     //May the time speed become zero.
            }
            else if (Time.timeScale == 0)
            {   //If the time speed is 0
                Time.timeScale = 1;     //May the time speed become one.

                /* if (canvasPause.GetComponent<Canvas>().enabled && canvasPanelPausa.ac)
                 {
                     ev.SetSelectedGameObject(resumeB);

                 }
                 else
                     ev.SetSelectedGameObject(null);*/

            }
        }

      
       

        //Clock gameplay
        //if (!starting)
        //{
        //    time = time - Time.deltaTime;
        //    min = time / 60;
        //    min = Mathf.FloorToInt(min);
        //    sec = Mathf.FloorToInt(time - min * 60);
        //    if (sec > 59)
        //    {
        //        sec = 0;
        //    }

        //    textTimer.text = string.Format("{0:00}:{01:00}", min, sec);

        //    if (time <1)
        //    {
        //        Time_up();//If the time reaches zero, we call the function that manages it.
        //    }

        //    //Para cuando se llena el tablero antes de que acabe el tiempo
        //    /*if(grid.transform.childCount ==0)

        //    {
        //        if (orb_controller.plantados.Length < orb_controller.suciedades.Length)//We check which player has the most tiles under the control
        //        {
        //            SceneManager.LoadScene("player2win");//And we load a scene depending on who won.
        //        }
        //        else
        //        {
        //            SceneManager.LoadScene("player1win");
        //        }
        //    }*/
        //}

      
    }

    static void Time_up()
    {
        //if (time < 1)
        //{
        //    //if (orb_controller.plantados.Length < orb_controller.suciedades.Length)//We check which player has the most tiles under the control
        //    //{
        //    //    SceneManager.LoadScene("player2win");//And we load a scene depending on who won.
        //    //}
        //    else
        //    {
        //        SceneManager.LoadScene("player1win");
        //    }
        //}
    }

}
