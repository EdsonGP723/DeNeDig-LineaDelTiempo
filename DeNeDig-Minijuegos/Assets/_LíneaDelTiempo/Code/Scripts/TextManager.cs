using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextManager : MonoBehaviour
{
    public static TextManager Instance = null;
    public TextAsset idiomaData;
    private string[] data;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(Instance!=this)
        {
            Destroy(gameObject);
        }

        GetData();

    }

    private void GetData()
    {
       data = idiomaData.text.Split(new string[]{",","\n"}, System.StringSplitOptions.None);
    }


    public string setText(int id)
    {
        for (int i = 0; i < data.Length; i++)
        {
            if (id.ToString() == data[i])
            {
               
            }
        }
        return data[id + PlayerPrefs.GetInt("Idioma")];
    }

}
