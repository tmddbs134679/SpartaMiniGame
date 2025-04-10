using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMananger : MonoBehaviour
{

    public static GameMananger Instance;

    public GameObject EndPanel;
    public Text title;
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
                SoundManager.instance.PlayOneShot(SoundType.ETC, clearAc);
                Time.timeScale = 0f;
                title.text = "성공!!";
                Game.GameManager.instance.OnStageClear();
                EndPanel.SetActive(true);
            }
        }

        
        
    }

    void MakeObstacle()
    {
        Instantiate(obstacle);

    }

    public void GameOver()
    {
  
        title.text = "실패 ㅠㅠ";
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

        EndPanel.SetActive(true);
    }

    void TimeStop()
    {
        Time.timeScale = 0.0f;
    }
}
