using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Descriptor")]
public class WaveContainer : ScriptableObject {

    public string waveName;
    public Transform enemy;
    public int count;
    public float rate;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
