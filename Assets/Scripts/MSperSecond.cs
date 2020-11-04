using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSperSecond : MonoBehaviour
{
    public EnemyController EnemyMS;

    void Start()
    {
        EnemyMS = GetComponent<EnemyController>();
        InvokeRepeating("MSEnemy", 30f, 30f);
    }

    void MSEnemy()
    {
        EnemyMS.MoveSpeed += 0.50f;
    }
}