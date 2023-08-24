using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private GameObject fichaPrefab;

    [SerializeField] private List<FichaData> Level01 = new List<FichaData>();
    [SerializeField] private List<FichaData> Level02 = new List<FichaData>();
    [SerializeField] private List<FichaData> Level03 = new List<FichaData>();

    private List<List<FichaData>> LevelsContainer= new List<List<FichaData>>();

    public int _LevelIndex;

    [SerializeField] private Vector2 spawnerPosition;
    [SerializeField] private float spaceBetween;
    //private List<FichaData>[] levels = new List<FichaData>[] { new List<FichaData>};

    private void Awake()
    {
        
    }
    void Start()
    {
        GetLevels();
        SortFichas();
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
    void SortFichas()
    {
        var actualLevel = LevelsContainer[_LevelIndex];


        var fichas = actualLevel.OrderBy(a=>Guid.NewGuid()).ToList();

        

        for (int i = 0; i <= fichas.Count-1; i++)
        {
            var actualObject = Instantiate(fichaPrefab).GetComponent<Ficha>();  
            
            actualObject._FichaData = fichas[i];

            actualObject.transform.position = new Vector3(spawnerPosition.x,spawnerPosition.y);

            spawnerPosition.x += spaceBetween;
        }
    }

  
  



  
}
