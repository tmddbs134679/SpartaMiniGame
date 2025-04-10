using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    [SerializeField]private List<CastleData> allStages; 
    private bool isEndingStart;

    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        if (IsAllStageCleared() && !isEndingStart)
        {
            isEndingStart = true;
            StartCoroutine(Game.GameManager.instance.GameEnding());
        }
    }

    public void ClearStage(CastleData currentStage)
    {
        int index = allStages.IndexOf(currentStage);
        if(index+1 < allStages.Count)
        {
            allStages[index + 1].isOpen = true;
        }
    }



    public bool IsAllStageCleared()
    {
        foreach (var stage in allStages)
        {
            if (!stage.isClear)
                return false;
        }
        return true;
    }
}
