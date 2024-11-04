using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSoundsEffects : MonoBehaviour
{
    //This script plays sound effects when main menu buttons are pressed.
    public AudioSource src;
    public AudioClip sfxBotonPulsado;//boton pulsado
    public AudioClip sfxBotonBack;//boton back

    public void Button_Pulsado()
    {
        src.clip = sfxBotonPulsado;
        src.Play();
    } 
    public void Button_Back()
    {
        src.clip = sfxBotonBack;
        src.Play();
    } 
   
}
