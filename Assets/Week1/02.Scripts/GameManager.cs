using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public StageResultEventChannel stageResultEventChannel;

    [SerializeField]private int totalScore;

    public Text totalScoreTxt;
    public Text timeTxt;
    public Text titleTxt;


    float totalTime = 30.0f;

    public AudioClip Clearclip;
    public bool isGame = false;

    private void Awake()
    {
        Instance = this;    
        Time.timeScale= 1.0f;
    }


    public GameObject Rain;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeRain", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(totalTime > 0)
        {
            totalTime -= Time.deltaTime;
        }
        else
        {
            if(!isGame)
            {
                totalTime = 0;
                stageResultEventChannel.Raise(RESULT.Fail);

                Time.timeScale = 0;
                isGame = true;
            }    
  
        }

        if(totalScore >= 20 && !isGame)
        {
          
            Time.timeScale = 0;

            Game.GameManager.instance.OnStageClear();
            stageResultEventChannel.Raise(RESULT.Success);



            isGame = true;
        }

        timeTxt.text = totalTime.ToString("F2");
    }

    void MakeRain()
    {
        Instantiate(Rain);
    }

    public void AddScore(int score)
    {
        totalScore+= score;
        totalScoreTxt.text = totalScore.ToString();
 
    }

}
