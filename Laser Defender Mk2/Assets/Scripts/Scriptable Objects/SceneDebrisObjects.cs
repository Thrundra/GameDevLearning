using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Background Debris Object")]
public class SceneDebrisObjects : ScriptableObject
{
    [SerializeField] GameObject[] a_BackgroundDebrisArray;
    [SerializeField] GameObject g_BaseWaypointPath;

}
