using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Descriptor")]
public class WaveContainer : ScriptableObject {

    [SerializeField] List<EnemyData> e_listOfEnemiesInWave;
}
