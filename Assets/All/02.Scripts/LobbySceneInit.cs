using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbySceneInit : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private Text title;
    [SerializeField] private GameObject GameUI;
    [SerializeField] private LobbyPlayer player;
    [SerializeField] private GameObject endingUI;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        Game.GameManager.instance.title = title; 
        Game.GameManager.instance.player = player;
        cameraFollow.player = player;

    }

}
