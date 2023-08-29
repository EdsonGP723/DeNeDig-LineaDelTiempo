using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int _LevelIndex;

    [SerializeField] private int fichasCount;


    [SerializeField] private GameObject fichaPrefab;

    [SerializeField] private List<FichaData> Level01 = new List<FichaData>();
    [SerializeField] private List<FichaData> Level02 = new List<FichaData>();
    [SerializeField] private List<FichaData> Level03 = new List<FichaData>();

    private List<List<FichaData>> LevelsContainer= new List<List<FichaData>>();

    public List<FichaData> ActualFichas = new List<FichaData>();

    public DropSlot[] slots;

    public int Score = 0;
    [SerializeField] private TextMeshProUGUI scoreLabel;

    [SerializeField] private int idioma;
    private void Awake()
    {
        
    }
    void Start()
    {
        GetLevels();
        GenerateFichas();
        PlayerPrefs.SetInt("Idioma", idioma);
    }


    void Update()
    {

    }

    void GetLevels()
    {
        LevelsContainer.Add(Level01);
        LevelsContainer.Add(Level02);
        LevelsContainer.Add(Level03);
    }
    void GenerateFichas()
    {
        var actualLevel = LevelsContainer[_LevelIndex];


        var fichas = actualLevel.OrderBy(a=>Guid.NewGuid()).ToList();

        

        for (int i = 0; i <= fichasCount-1; i++)
        {
            var actualObject = Instantiate(fichaPrefab,transform).GetComponent<Ficha>();  
            
            actualObject._FichaData = fichas[i];

            ActualFichas.Add(actualObject._FichaData);

        }

        SortFichas();
    }

    void SortFichas()
    {
        var sortedList = ActualFichas.OrderByDescending(x => x.Year).ToList();

        ActualFichas.Clear();
        
        for(int i = 0 ; i  <= sortedList.Count-1; i++)
        {
            ActualFichas.Add(sortedList[i]);
        }
        AsignSlots();
    }

    public void AsignSlots(){
        for (int i = 0; i <= slots.Length - 1; i++){
            slots[i].year = ActualFichas[i].Year;
        } 
        
    }
  

    public void Check()
    {
        Score = 0;
        for (int i = 0; i <= slots.Length - 1; i++)
        {
            if (slots[i].Correct)
            {
                Score++;
            }
        }
        var FinalScore = Score * Globals.Score;
        Debug.Log(Score);
        scoreLabel.text = "Puntaje: "+FinalScore;
    }



  
}
