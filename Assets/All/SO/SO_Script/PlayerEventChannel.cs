using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "EventChannels/Player")]
public class PlayerEventChannel : ScriptableObject
{
  public UnityAction<bool> OnPlayerEvent;

  public void Raise(bool toggle) => OnPlayerEvent?.Invoke(toggle);
  
}
