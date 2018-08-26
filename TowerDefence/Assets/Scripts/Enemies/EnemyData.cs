using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyType")]
public class EnemyData : ScriptableObject {

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float enemySpeed;
    [SerializeField] int enemyHits;

}
