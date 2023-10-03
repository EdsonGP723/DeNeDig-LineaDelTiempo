using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    public Slider sliderMusic;
    public float sliderValueMusic;
    

    private void Start()
    {
        sliderMusic.value = PlayerPrefs.GetFloat("volumenMusica", 0.5f);
        AudioListener.volume = sliderMusic.value;

        /*sliderMusic.value = PlayerPrefs.GetFloat("volumenMusica",0.5f);
        //sliderMusic.value = AudioManager.musicVolume;
        AudioListener.volume = sliderValueMusic.value;*/

        //sliderMusic = AudioManager.Instance.SetVolume(0.5f,AudioManager.AudioChannel.Music);
    }

    public void SetMusicVolume( float valor)
    {
        sliderValueMusic = valor;
        PlayerPrefs.SetFloat("volumenMusica",sliderValueMusic);
        AudioListener.volume = sliderMusic.value;

    }
}
