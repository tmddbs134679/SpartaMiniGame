using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCastle : MonoBehaviour
{
  
    public CastleData data; 

    void OnMouseDown()
    {
        if (!data.isOpen)
            return;

        Vector2 offset = data.stage == 0 ? new Vector2(0, 2f) : Vector2.zero;
        Vector2 dest = (Vector2)transform.position + offset;

        var gm = Game.GameManager.instance;
        gm.player.MoveTo(dest, data.stage, gm.OnPlayerArrived);
        gm.SetTargetCastle(data);

    }
}
