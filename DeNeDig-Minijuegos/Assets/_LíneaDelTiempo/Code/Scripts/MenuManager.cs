using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private TMP_InputField userNameInputField;
    [SerializeField] private TextMeshProUGUI wariningField;
    [SerializeField] private GameObject actualScreen;
    [SerializeField] private GameObject nextScreen;
    public void SetUserName()
    {
        if (userNameInputField.text.Length < 5) { 
            wariningField.text = "El nombre de usario debe tener más de 5 carácteres";
            return;
            }
        PlayerPrefs.SetString("UserName", userNameInputField.text);
        nextScreen.SetActive(true);
        actualScreen.SetActive(false);
    }

    public void SetLanguage(int language)
    {
        PlayerPrefs.SetInt("Idioma", language);
    }
}
