using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CARD
{
    public class GameManager : MonoBehaviour
    {
        static public GameManager instance;


        [Header("Card Settings")]
        public int cardCount = 0;
        public Card firstcard;
        public Card secondcard;


        [Header("Timer Settings")]
        public Text timeTxt;
        private float timer = 30;
  

        [Header("Audio Settings")]
        public AudioClip clip;
        AudioSource audiosource;

        [Header("Settings")]
        public GameObject endPanel;
        public Text title;
        private bool isWarning = true;
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
             
        }

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1;
            audiosource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            timer -= Time.deltaTime;
            timeTxt.text = timer.ToString("F2");

            if (timer <= 10 && isWarning)
            {
                TimeWarning();
                isWarning = false;
            }

            if (timer <= 0)
            {
                title.text = "실패ㅠㅠ";
                GameOver();
            }
        }

        public void Matched()
        {
            if(firstcard.idx == secondcard.idx)
            {
                audiosource.PlayOneShot(clip);
                firstcard.DestoryCard();
                secondcard.DestoryCard();
                cardCount -= 2;
                if(cardCount <= 0)
                {
                    title.text = "성공!!";
                    Game.GameManager.instance.OnStageClear();
                    GameOver();
                }

            }
            else
            {
                firstcard.CloseCard();
                firstcard.isOpen = false;
                secondcard.CloseCard();
                secondcard.isOpen = false;
            }

            firstcard = null;
            secondcard = null;
        }
        void GameOver()
        {

            timeTxt.text = "0.00";
            Time.timeScale = 0;
            endPanel.SetActive(true);
        }

        void TimeWarning()
        {
            timeTxt.color = Color.red;
        }

    }

 
}
