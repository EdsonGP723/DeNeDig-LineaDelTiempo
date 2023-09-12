using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using TMPro;
using Dan.Main;
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

    
    [SerializeField] private TextMeshProUGUI aciertosLabel;

    public int Score = 0;

    [SerializeField] private Timer time;

    [SerializeField] private TextMeshProUGUI scoreLabel;

    [SerializeField] private int idioma;

    private static string publicKey = "4d20065bde55aba7263e07336e9700cc9ed70e2784ecc740ae4253ae301e2e5a";

    [SerializeField] private List<TextMeshProUGUI> userNames;
    [SerializeField] private List<TextMeshProUGUI> scores;
    [SerializeField] private TextMeshProUGUI myUserName;
    [SerializeField] private TextMeshProUGUI myScore;

    [SerializeField] private TMP_InputField userNameInputField;
    [SerializeField] private TextMeshProUGUI wariningField;

    private int FinalScore;
    private void Awake()
    {
        
    }
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("UserName"));
        GetLevels();
        GenerateFichas();
        PlayerPrefs.SetInt("Idioma", idioma);
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
        
        time._timmerIsRunning = false;
        Score = 0;
        for (int i = 0; i <= slots.Length - 1; i++)
        {
            if (slots[i].Correct)
            {
                Score++;
            }
        }
        float finalScore = Score * Globals.Score;
       



        aciertosLabel.text = "Aciertos: "+Score + "/5";
        


        scoreLabel.text = "Puntaje: "+ Math.Round(finalScore);

        FinalScore = ((int)finalScore);
        GetLeaderBoard();

    }

    public void GetLeaderBoard()
    {
       
        LeaderboardCreator.GetLeaderboard(publicKey, ((msg) => {
            for(int i = 0; i < userNames.Count; ++i)
            {
                
                userNames[i].text = (msg[i].Rank +".-"+ msg[i].Username);
                scores[i].text = msg[i].Score.ToString();

               
            }

            /*foreach (var item in msg)
            {
                if (PlayerPrefs.GetString("UserName") == item.Username)
                {
                    myUserName.text = item.Rank + ".-" + item.Username;
                    myScore.text = item.Score.ToString();
                }
            }*/
        }));


    }

    public void SetLeaderBoardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicKey, username, score, ((msg) => {
            LeaderboardCreator.ResetPlayer();
            GetLeaderBoard();
        }));

       
    }

    public void SetUserName()
    {
        if (userNameInputField.text.Length < 5)
        {
            wariningField.gameObject.SetActive(true);
            return;
        }
        PlayerPrefs.SetString("UserName", userNameInputField.text);
       
        SetLeaderBoardEntry(userNameInputField.text, FinalScore);
    }



}
