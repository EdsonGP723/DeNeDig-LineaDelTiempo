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


    private void Start()
    {
        if (Globals.idiomaWasSelected){
            idiomaScreen.SetActive(false);
            menuScreen.SetActive(true);
        }
    }

    public void idiomaSelected()
    {
        Globals.idiomaWasSelected = true;
    }

    public void SetLanguage(int language)
    {
        PlayerPrefs.SetInt("Idioma", language);
    }
}
