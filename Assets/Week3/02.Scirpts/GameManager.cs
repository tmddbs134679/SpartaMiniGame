using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace cat
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance;

        public GameObject normalCat;
        public GameObject fatCat;
        public GameObject PircateCat;

        public GameObject EndPanel;

        private bool isGameClear = false;
        public Text title;
        int score;
        int level;

        private bool isPlay = true;

        public AudioClip clearAc;

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
                GameEnd();
            }
        }


        void MakeCat()
        {
          
                Instantiate(normalCat);

                if (level == 1)
                {
                    int p = Random.Range(0, 10);

                    if (p < 2)
                        Instantiate(normalCat);

                }
                else if (level == 2)
                {
                    int p = Random.Range(0, 10);

                    if (p < 5)
                        Instantiate(normalCat);
                }
                else if (level == 3)
                {
                    Instantiate(fatCat);
                }
                else if (level == 4)
                {
                    Instantiate(PircateCat);
                }
 

        }

        public void GameEnd()
        {
      
            SoundManager.instance.StopLoop(SoundType.Player);
            SoundManager.instance.PlayOneShot(SoundType.ETC, clearAc);

            Time.timeScale = 0;
            title.text = "성공!!";
            EndPanel.SetActive(true);
            Game.GameManager.instance.OnStageClear();
            isPlay = false; 
        }

        public void Gameover()
        {
            if(isPlay )
            {
      
                Time.timeScale = 0;
                title.text = "실패ㅠㅠ";
                EndPanel.SetActive(true);
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
