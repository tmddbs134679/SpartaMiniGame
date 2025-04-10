using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TYPE
{
    Lobby,
    Game
}

public enum RESULT
{
    Success,
    Fail
}

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject GameUI;
    public GameObject EndingUI;
    private Text title;
   [SerializeField]private Button lobbyBtn;
   [SerializeField]private Button retryBtn;
   [SerializeField]private Button startBtn;
   [SerializeField] private Button cancleBtn;

    private string[] result = { "성공!!", "실패ㅠㅠ" };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
           
        else 
            Destroy(gameObject);
    }

    private void Start()
    {
        Transform root = GameUI.transform;
        title = root.Find("GameObject/BackGround/Title[TXT]").GetComponent<Text>();
        startBtn = root.Find("GameObject/BackGround/StartBtn").GetComponent<Button>();
        retryBtn = root.Find("GameObject/BackGround/RetryBtn").GetComponent<Button>();
        lobbyBtn = root.Find("GameObject/BackGround/LobbyBtn").GetComponent<Button>();
        cancleBtn = root.Find("GameObject/BackGround/CancleBtn").GetComponent<Button>(); 
    }
    public void ShowGameUI(string gameTitle)
    {
        GameObject gameui =  Instantiate(GameUI, new Vector2(0,0), Quaternion.identity);
        title.text = gameTitle;
    }

    public void ShowGameUI(TYPE tpye, RESULT result)
    {
        GameObject gameui = Instantiate(GameUI, new Vector2(0, 0), Quaternion.identity);


        if (tpye == TYPE.Game)
        {

        }

    }


    public void ShowEndingUI()
    {
        EndingUI.SetActive(true);
    }

}
