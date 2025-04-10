using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]private int totalScore;

   // public GameObject EndPanel;

    public Text totalScoreTxt;
    public Text timeTxt;
    public Text titleTxt;
    float totalTime = 30.0f;

    public AudioClip Clearclip;
    public bool isGameClear = false;


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
            totalTime = 0;
            titleTxt.text = "실패ㅠㅠ";
            //UIManager.instance.ShowGameUI();
            //EndPanel.SetActive(true);
            Time.timeScale = 0;
        }

        if(totalScore >= 20 && !isGameClear)
        {
          
            Time.timeScale = 0;
            titleTxt.text = "성공!!";
            SoundManager.instance.PlayOneShot(SoundType.ETC, Clearclip);
            Game.GameManager.instance.OnStageClear();
           // EndPanel.SetActive(true);
            isGameClear = true;
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
