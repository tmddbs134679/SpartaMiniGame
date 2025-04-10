using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Castle/CastleData")]
public class CastleData : ScriptableObject
{
    public int stage;
    public string gameTitle;
    public bool isOpen;
    public bool isClear;
    public string sceneName;
 
}
