using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBTN : MonoBehaviour
{
    public string nombreInstruccion;
    public void BtnSonido(string nombre)
    {
        AudioManager.Instance.PlaySound2D(nombre);
        StartCoroutine(SigInstruccion());
    }

    public IEnumerator SigInstruccion()
    {
        yield return new WaitForSeconds(0.5f);
        AudioManager.Instance.PlaySound2D(nombreInstruccion);
    }
}
