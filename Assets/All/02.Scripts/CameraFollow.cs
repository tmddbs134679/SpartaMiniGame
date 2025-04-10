using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public LobbyPlayer player;
    private Vector3 LastCameraPos;

    // Start is called before the first frame update
    void Start()
    {
            LastCameraPos = new Vector3
            (
                 PlayerPrefs.GetFloat("cam_x", 0f),
                 PlayerPrefs.GetFloat("cam_y", 0f),
                 PlayerPrefs.GetFloat("cam_z", -10f)
            );
        
         transform.position = LastCameraPos;
        
      
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void LateUpdate()
    {
        if (player == null)
            return;

        if (player.isMoving || StageManager.instance.IsAllStageCleared())
        {
            Vector3 targetPos = player.transform.position;
            targetPos.x = 0f;
            targetPos.z = -10f;

            targetPos.y = Mathf.Clamp(targetPos.y, 0f, 23f);

            transform.position = targetPos;
            SaveCameraPos();

        }
    }

    private void SaveCameraPos()
    {
       LastCameraPos =  Camera.main.transform.position;
        PlayerPrefs.SetFloat("cam_x", LastCameraPos.x);
        PlayerPrefs.SetFloat("cam_y", LastCameraPos.y);
        PlayerPrefs.SetFloat("cam_z", LastCameraPos.z);
        PlayerPrefs.Save();
    }

    public void CameraSetting(Vector3 pos)
    {
        transform.position = pos;
    }
}
