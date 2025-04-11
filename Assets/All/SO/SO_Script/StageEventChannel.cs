using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "EventChannels/StageResult")]
public class StageResultEventChannel : ScriptableObject
{
    public UnityAction<RESULT> OnGameResult;

    public void Raise(RESULT result) => OnGameResult?.Invoke(result);
}