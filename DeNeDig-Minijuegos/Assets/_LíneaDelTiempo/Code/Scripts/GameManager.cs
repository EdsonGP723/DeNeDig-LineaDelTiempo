using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
public class GameManager : MonoBehaviour
{
    
    [SerializeField] private GameObject fichaPrefab;

    public CollectionWrapper<FichaData>[] Levels;

    public int _Level;

    [SerializeField] private Vector2 spawnerPosition;
    [SerializeField] private float spaceBetween;
    //private List<FichaData>[] levels = new List<FichaData>[] { new List<FichaData>};

    private void Awake()
    {
        
    }
    void Start()
    {
        SortFichas();
    }


    void Update()
    {

    }
    void SortFichas()
    {
        var fichas = Levels[_Level].Value;

     
        
        for(int i = 0; i <= fichas.Length-1; i++)
        {
            var actualObject = Instantiate(fichaPrefab).GetComponent<Ficha>();  
            
            actualObject._FichaData = fichas[i];

            actualObject.transform.position = new Vector3(spawnerPosition.x,spawnerPosition.y);

            spawnerPosition.x += spaceBetween;
        }
    }

  
  



  
}
