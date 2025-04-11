using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMananger : MonoBehaviour
{

    public static GameMananger Instance;

    public StageResultEventChannel stageResultEventChannel;

    public bool isPlay = true;
    public bool isGameClear = false;

    public Animator anim;

    public GameObject obstacle;
    float timer = 20f;
    public Text timeTxt;
    string key = "bestScore";
    public AudioClip clearAc;



    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

    }

    private void Start()
    {
        isPlay = true;
        Time.timeScale = 1f;
        InvokeRepeating("MakeObstacle", 0, 1f);
    }

    private void Update()
    {
        if(isPlay)
        {
            timer -= Time.deltaTime;
            timeTxt.text = timer.ToString("F2");

            if(timer <= 0 && !isGameClear)
            {
                isGameClear = true;
                Time.timeScale = 0f;
                Game.GameManager.instance.OnStageClear();
                stageResultEventChannel.Raise(RESULT.Success);
            }
        }

        
        
    }

    void MakeObstacle()
    {
        Instantiate(obstacle);

    }

    public void GameOver()
    {
        stageResultEventChannel.Raise(RESULT.Fail);

        isPlay = false;
        anim.SetBool("isDie", true);

        Invoke("TimeStop", 0.5f);

        if(PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);

            if (best < timer)
            {
                PlayerPrefs.SetFloat(key, timer);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(key, timer);
        }
    }

    void TimeStop()
    {
        Time.timeScale = 0.0f;
    }
}
