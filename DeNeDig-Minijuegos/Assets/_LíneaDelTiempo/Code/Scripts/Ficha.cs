using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ficha : MonoBehaviour
{
    private int level;

    private int index;

    private string title;

    private string description;

    private Sprite image;

    public FichaData _FichaData;

    void Start()
    {
        level = _FichaData.Level;
        index = _FichaData.Index;
        title = _FichaData.Title;
        description = _FichaData.Description;
        image = _FichaData.Image;


    }

   
}
