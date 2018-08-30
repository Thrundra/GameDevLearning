﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyType")]
public class EnemyData : ScriptableObject {

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float enemySpeed;
    [SerializeField] int enemyHits;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public float GetEnemySpeed()
    {
        return enemySpeed;
    }

    public int GetEnemyHits()
    {
        return enemyHits;
    }

}