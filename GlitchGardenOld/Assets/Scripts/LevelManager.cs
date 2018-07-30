using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField] float autoLoadNextLevelAfter;
    LevelManager nextScene;  // Cache
    SceneManager loadScene;

	// Use this for initialization
	void Start ()
    {
        Invoke("LoadNextLevel", autoLoadNextLevelAfter);
      //  nextScene = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void LoadNextScene(int nextSceneValue)
    {
        SceneManager.LoadScene(nextSceneValue);
    }

    public void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene == 0)
        {
            Debug.Log("Current scene:" + currentScene);
            currentScene += 1;
            SceneManager.LoadScene(currentScene);
        }
    }
}
