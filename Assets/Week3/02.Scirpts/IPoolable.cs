using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    void OnSpawn();     // 꺼내쓸 때 호출
    void OnDespawn();   // 반납할 때 호출
}