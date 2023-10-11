using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private TMP_InputField userNameInputField;
    [SerializeField] private TextMeshProUGUI wariningField;
    [SerializeField] private GameObject idiomaScreen;
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private AnimationsManager animationsManager;

    [SerializeField] private Scenes sceneManager;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject reglasPanel;


    private void Start()
    {
        if (Globals.idiomaWasSelected){
            idiomaScreen.SetActive(false);
            menuScreen.SetActive(true);
            animationsManager.EntraMenu();
        }
    }

    public void idiomaSelected()
    {
        Globals.idiomaWasSelected = true;
    }

    public void Play()
    {
        if (Globals.firstPlay)
        {
          
            reglasPanel.SetActive(true);
            AudioManager.Instance.StopSound();
            AudioManager.Instance.PlaySound2D("01");
            Globals.firstPlay = false;
            menuPanel.SetActive(false);
        }
        else
        {
            Debug.Log("Cambio de escena");
            sceneManager.StartCor(1);
        }
    }

    public void SetLanguage(int language)
    {
        PlayerPrefs.SetInt("Idioma", language);
        Debug.Log(PlayerPrefs.GetInt("Idioma"));
    }
}
