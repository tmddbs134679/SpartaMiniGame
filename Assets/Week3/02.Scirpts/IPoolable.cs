using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    void OnSpawn();     // ������ �� ȣ��
    void OnDespawn();   // �ݳ��� �� ȣ��
}