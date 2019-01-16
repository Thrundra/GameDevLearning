using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [SerializeField] private float _waitDuration = 2.0f;
    // Update is called once per frame
    void Update()
    {

    }

    public void Level_StartNewGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Level_LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Level_GameOver()
    {
        SceneManager.LoadScene(1);
    }

    public void Level_QuitGame()
    {
        Application.Quit();
    }

    public void Level_LoadNextGameLevel()
    {
        int _currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(_currentScene + 1);
    }

    public void DelayLoadScene(string type)
    {
        if(type=="PlayerDeath")
        {
            StartCoroutine(WaitForDeathToPlay());
        }
    }

    IEnumerator WaitForDeathToPlay()
    {
        yield return new WaitForSeconds(5);
        Level_GameOver();
    }
}

