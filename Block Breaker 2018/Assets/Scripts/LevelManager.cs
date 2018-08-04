using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField] int breakableBlocks;  // Debug purposes only
    SceneLoader nextScene;  // Cache

	// Use this for initialization
	void Start ()
    {
        nextScene = FindObjectOfType<SceneLoader>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
             nextScene.LoadNextScene();
        }
    }
}
