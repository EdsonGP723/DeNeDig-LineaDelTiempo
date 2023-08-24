using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Ficha : MonoBehaviour
{
    private int level;

    public int index;

    private string title;

    private string description;

    private Sprite image;

    public FichaData _FichaData;

    [SerializeField] private TextMeshProUGUI titleLabel;
    [SerializeField] private TextMeshProUGUI descriptionLabel;
    [SerializeField] private  Image sourceImage;
    void Start()
    {
        GetData();
        SetData();
        
    }

    void SetData()
    {
        titleLabel.text = title;
        descriptionLabel.text = description;
        sourceImage.sprite = image;
    }
    void GetData()
    {
        level = _FichaData.Level;
        index = _FichaData.Index;
        title = _FichaData.Title;
        description = _FichaData.Description;
        image = _FichaData.Image;
    }

   
}
