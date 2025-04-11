using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio/GameAudioClips")]
public class GameAudioClips : ScriptableObject
{
    [Header("UI Sound")]
    public AudioClip stageClearClip;
    public AudioClip stageFailClip;
    public AudioClip buttonClick;

    [Header("Object Sound")]
    public AudioClip catClip;
    public AudioClip playerAttackClip;
    public AudioClip[] boxCrushClips;
    public AudioClip endingUIClip;

}