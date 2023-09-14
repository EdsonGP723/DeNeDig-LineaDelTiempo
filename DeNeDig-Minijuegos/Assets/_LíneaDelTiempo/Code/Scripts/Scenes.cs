using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public int scene;
    public GameObject fade;

    public void StartCor(){
        StartCoroutine(Cambio());

    }
   public IEnumerator Cambio(){
        fade.SetActive(true);
        
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
