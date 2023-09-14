using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audios : MonoBehaviour
{
    public string nombreClip;
    // Start is called before the first frame update
    void Start()
    {
        MusicaFade(nombreClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MusicaFade(string nombreClip)
    {
        StartCoroutine(AudioManager.Instance.PlayMusicFade(nombreClip, 5f));
    }
}
