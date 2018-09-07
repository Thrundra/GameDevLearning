using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyType")]
public class EnemyData : ScriptableObject {

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float enemySpeed;
    [SerializeField] int maxEnemyHits;
    [SerializeField] int enemyArmourAmount;
    [SerializeField] int playerLifeCost;

    // Private Variables needed
    private int currentEnemyHits;

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
        return currentEnemyHits;
    }

    public void AddDamageToEnemy(int value)
    {
        currentEnemyHits += value;
        CheckIfEnemyDead();
    }

    private void CheckIfEnemyDead()
    {
        if(currentEnemyHits >= maxEnemyHits)
        {
            EnemyDeathProcess();
        }
    }

    private void EnemyDeathProcess()
    {
        // Run the Death Sound.

        // Run the death animation.

        // Destroy the gameObject
    }
}
