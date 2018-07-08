using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

  //  [SerializeField] public string sceneName;

    public void ChangeScene(string sceneName)
    {
        //string sceneName = 
        SceneManager.LoadScene(sceneName);
    }
}
