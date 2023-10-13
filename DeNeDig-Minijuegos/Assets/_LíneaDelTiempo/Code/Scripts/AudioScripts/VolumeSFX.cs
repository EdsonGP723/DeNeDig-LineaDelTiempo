using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSFX : MonoBehaviour
{
    public Slider sliderSFX;
    // Start is called before the first frame update
    void Start()
    {
        sliderSFX.value = PlayerPrefs.GetFloat("volumenSFX", 0.5f);
        PlayerPrefs.SetFloat("volumenSFX", sliderSFX.value);
        AudioManager.Instance.SetVolume(PlayerPrefs.GetFloat("volumenSFX"), AudioManager.AudioChannel.Music);
    }

    public void ChangeSliderSFX()
    {
        PlayerPrefs.SetFloat("volumenSFX", sliderSFX.value);

        AudioManager.Instance.SetVolume(PlayerPrefs.GetFloat("volumenSFX"), AudioManager.AudioChannel.fx);
    }
}
