using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ficha : MonoBehaviour
{
    private int level;

    public int index;

    private string title;

    private string description;

    private Sprite image;

    public FichaData _FichaData;

    [SerializeField] private TextMeshPro titleLabel;
    [SerializeField] private TextMeshPro descriptionLabel;
    [SerializeField] private SpriteRenderer spriteRenderer;
    void Start()
    {
        GetData();
        SetData();
        
    }

    void SetData()
    {
        titleLabel.text = title;
        descriptionLabel.text = description;
        spriteRenderer.sprite = image;
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
