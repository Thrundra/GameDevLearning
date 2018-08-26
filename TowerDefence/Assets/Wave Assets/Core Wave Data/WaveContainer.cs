using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Descriptor")]
public class WaveContainer : ScriptableObject
{
    [SerializeField] List<WaveEnemyAmount> e_EnemyWaveData;
}
