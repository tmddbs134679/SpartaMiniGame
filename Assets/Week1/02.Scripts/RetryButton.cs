using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{

    public AudioClip ac;

  public void Retry()
  {
        SoundManager.instance.PlayOneShot(SoundType.ETC, ac);

        string sceneName = Game.GameManager.instance.GetStageSceneName();

        SceneManager.LoadScene(sceneName);

        
  }

    public void Robby()
    {
        SoundManager.instance.PlayOneShot(SoundType.ETC, ac);

        SceneManager.LoadScene("LobbyScene");
    }

    public void OnClickQuitButton()
    {
            #if UNITY_EDITOR
                    EditorApplication.isPlaying = false; 
            #else
                Application.Quit();
            #endif

    }
}
