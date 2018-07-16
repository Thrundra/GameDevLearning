using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    // Setup Config
    [SerializeField] public int sceneIndex;


    public void ChangeLevel()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
