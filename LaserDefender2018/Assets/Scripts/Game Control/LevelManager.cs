using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		
	}

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGameMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(2);
    }
}
