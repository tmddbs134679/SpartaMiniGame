using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

enum CATTYPE
{
    NORMAL,
    FAT,
    PIRCATE
}

namespace cat
{
    public class GameManager : MonoBehaviour
    {
        public StageResultEventChannel stageResultEventChannel;
        public static GameManager instance;

        public GameObject[] cats;

        private bool isGameClear = false;
        int score;
        int level;
        private bool isPlay = true;
        public RectTransform levelbar;
        public Text levelTxt;


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            Time.timeScale = 1.0f;
        }
        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("MakeCat", 0, 1f);
        }

        // Update is called once per frame
        void Update()
        {
            if (level >= 6 && isPlay && !isGameClear) 
            {
                isGameClear = true;
                stageResultEventChannel?.OnGameResult(RESULT.Success);
                GameEnd();
            }
        }


        void MakeCat()
        {

                Instantiate(cats[(int)CATTYPE.NORMAL]);

                if (level == 1)
                {
                    int p = Random.Range(0, 10);

                    if (p < 2)
                        Instantiate(cats[(int)CATTYPE.NORMAL]);

                }
                else if (level == 2)
                {
                    int p = Random.Range(0, 10);

                    if (p < 5)
                        Instantiate(cats[(int)CATTYPE.NORMAL]);
                }
                else if (level == 3)
                {
                    Instantiate(cats[(int)CATTYPE.FAT]);
                }
                else if (level == 4)
                {
                    Instantiate(cats[(int)CATTYPE.PIRCATE]);
                }
 

        }

        public void GameEnd()
        {
            Time.timeScale = 0;
            SoundManager.instance.StopLoop(SoundType.Player);
            Game.GameManager.instance.OnStageClear();
            isPlay = false; 
        }

        public void Gameover()
        {
            if(isPlay)
            {
                SoundManager.instance.StopLoop(SoundType.Player);
                stageResultEventChannel?.OnGameResult(RESULT.Fail);
                Time.timeScale = 0;
            }
        

        }

        public void AddScore()
        {
            score++;

            level = score / 5;
            levelTxt.text = level.ToString();
            levelbar.localScale = new Vector3((score - level * 5) / 5.0f, 1, 1);
        }
    }

}
