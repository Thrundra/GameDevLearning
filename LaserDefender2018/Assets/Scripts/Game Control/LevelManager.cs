using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField] float delayInSeconds = 2f;

	// Update is called once per frame
	void Update () {
		
	}

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameControl>().ResetScore();
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
        StartCoroutine(PauseAfterDeath());
    }

    IEnumerator PauseAfterDeath()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(2);
    }
}
