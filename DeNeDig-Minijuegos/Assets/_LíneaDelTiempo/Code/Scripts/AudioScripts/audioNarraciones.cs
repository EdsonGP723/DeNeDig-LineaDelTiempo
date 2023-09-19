using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioNarraciones : MonoBehaviour
{
    public string nombreclip;

    private void Update()
    {
       
    }

    public void Narracion()
    {
        AudioManager.Instance.PlaySound2D(nombreclip);
    }
}
