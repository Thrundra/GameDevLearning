using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "All Waves")]
public class Waves : ScriptableObject {

    // Configuration
    [SerializeField] List<WaveContainer> allWaveDataforLevel;
}
