using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject controlsUI,menuUI, playButton, optionsUI, resumeB, backbuttonControls, backbuttonOptions, OptionsButton;
    public EventSystem ev;
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public TMP_Dropdown resolutionsDropdown;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentresolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height)
            {
                currentresolutionIndex = i;
            }
        }
        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentresolutionIndex;
        resolutionsDropdown.RefreshShownValue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 0)//boton de pausa
        {
            controlsUI.SetActive(false);
            //menuUI.SetActive(true);
            ev.SetSelectedGameObject(playButton);

            if (Time.timeScale == 0)
            {
                optionsUI.SetActive(false);
                ev.SetSelectedGameObject(resumeB);
            }
        }
    }

    public void Back()
    {
        ev.SetSelectedGameObject(resumeB);
    }

    public void resume()
    {
        gameObject.GetComponent<Canvas>().enabled = !gameObject.GetComponent<Canvas>().enabled;//We enable the canvas pause.
        if (Time.timeScale == 0)
        {   //If the time speed is 0
            Time.timeScale = 1;     //May the time speed become one.
        }
        print("resume");
    }

    public void controls()
    {
        ev.SetSelectedGameObject(backbuttonControls);
    }

    public void options()
    {
        ev.SetSelectedGameObject(backbuttonOptions);
    }
    //Function called from a OnClick button event.
    public void Jugar()
    {
        StartCoroutine("jugar");
    }

    //Quit function called from a OnClick button event.
    public void Exit()
    {
        Application.Quit();
    }

    public void optionsPanel()
    {
        ev.SetSelectedGameObject(OptionsButton);
    }

    //Restart the game
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    //Quit function called from a OnClick button event.
    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); //Poner nombre de la escena.
    }

    //Coroutine to make a smoother transition between the click of the button and the load of the next scene.
    public IEnumerator jugar()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Gameplay"); //Poner nombre de la escena.
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullscreeen(bool isFullscreeen)
    {
        Screen.fullScreen = isFullscreeen;
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
