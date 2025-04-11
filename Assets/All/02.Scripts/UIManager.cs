using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UITYPE
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

    [Header("UI Setting")]
    public GameObject GameUI;
    public GameObject EndingUI;
    [SerializeField] private Text title; 
    [SerializeField]private Button lobbyBtn;
    [SerializeField]private Button retryBtn;
    [SerializeField]private Button startBtn;
    [SerializeField]private Button cancleBtn;

    private string[] results = { "성공!!", "실패ㅠㅠ" };

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
        //Find 비용 자체가 크고 버튼이 계속 늘어나면 성능이 떨어지기 때문에 나중에 MVC 패턴으로 수정해야 함.
        Transform root = GameUI.transform;
        title = root.Find("GameObject/BackGround/Title[TXT]").GetComponent<Text>();
        startBtn = root.Find("GameObject/BackGround/StartBtn").GetComponent<Button>();
        retryBtn = root.Find("GameObject/BackGround/RetryBtn").GetComponent<Button>();
        lobbyBtn = root.Find("GameObject/BackGround/LobbyBtn").GetComponent<Button>();
        cancleBtn = root.Find("GameObject/BackGround/CancleBtn").GetComponent<Button>(); 
    }
    public void ShowGameUI(string gameTitle)
    {
        SetButtonState(UITYPE.Lobby);

        title.text = gameTitle;
        GameObject gameui =  Instantiate(GameUI, new Vector2(0,0), Quaternion.identity);
     
    }

    public void ShowGameUI(RESULT result)
    {
        SetButtonState(UITYPE.Game);

        if (result == RESULT.Success)
        {
            title.text = results[0];
        }
        else
        {
            title.text = results[1];
        }

        GameObject gameui = Instantiate(GameUI, new Vector2(0, 0), Quaternion.identity);
    }


    public void ShowEndingUI()
    {
        EndingUI.SetActive(true);
    }

    public void SetButtonState(UITYPE type)
    {
        bool isactive = true;

        if(type == UITYPE.Lobby)
            isactive = false;
        else
            isactive = true;

        startBtn.gameObject.SetActive(!isactive);
        retryBtn.gameObject.SetActive(isactive);
        lobbyBtn.gameObject.SetActive(isactive);
    }

}
