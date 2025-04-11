using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
  
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;


        public StageResultEventChannel eventChannel;
        public LobbyPlayer player;
        [SerializeField] private CastleData targetCastleData;

        public LobbyData lobbydata;
        public Text title;
        [SerializeField] private GameObject TestObj;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
              
          

            Application.targetFrameRate = 60;
        }


        private void Start()
        {
        
        }

        public string GetStageSceneName() => targetCastleData.sceneName;


        
        public void SetTargetCastle(CastleData data)
        {
            targetCastleData = data;
           
        }

        public void OnPlayerArrived()
        {
            lobbydata.currentpos = player.transform.position;

            if (StageManager.instance.IsAllStageCleared() && player.currentStage == 0)
            {
                UIManager.instance.ShowEndingUI();
            }
            else if (player.currentStage == 0)
            {
                return;
            }
            else
            {
                UIManager.instance.ShowGameUI(targetCastleData.gameTitle);
            }
        }


        public void OnStageClear()
        {
            targetCastleData.isClear = true;
            StageManager.instance.ClearStage(targetCastleData);
        }

       

        public IEnumerator GameEnding()
        {
            yield return StartCoroutine(player.PlayerEnding());

            player.PlayClearAnimation();

            OnPlayerArrived();

            Instantiate(TestObj, new Vector3(0, 15, 0), Quaternion.identity);

        }

    }




}
