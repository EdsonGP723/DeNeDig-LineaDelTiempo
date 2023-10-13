using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider sliderMusic;

    // Start is called before the first frame update
    void Start()
    {
        sliderMusic.value = PlayerPrefs.GetFloat("volumenMusica",0.5f);
        PlayerPrefs.SetFloat("volumenMusica", sliderMusic.value);
        AudioManager.Instance.SetVolume(PlayerPrefs.GetFloat("volumenMusica"), AudioManager.AudioChannel.Music);
        ;
    }

     public void ChangeSlider()
    {
        PlayerPrefs.SetFloat("volumenMusica", sliderMusic.value);
        
        AudioManager.Instance.SetVolume(PlayerPrefs.GetFloat("volumenMusica"),AudioManager.AudioChannel.Music);
    }

    

}
