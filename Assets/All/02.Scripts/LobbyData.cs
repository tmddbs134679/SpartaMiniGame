using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Lobby/LobbyData")]
public class LobbyData : ScriptableObject
{
    public Vector2 currentpos;
    public bool[] isOpenCastle;

}
