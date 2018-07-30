using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    [SerializeField] public AudioClip[] levelMusicChangeArray;

    private AudioSource musicAudio;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load: " + name);
        musicAudio = GetComponent<AudioSource>();

    }

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneWasLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneWasLoaded;
    }

    private void OnSceneWasLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        
        Debug.Log("Current Scene: " + scene.buildIndex);

        AudioClip levelMusic = levelMusicChangeArray[scene.buildIndex];

        if(levelMusic)
        {
            musicAudio.clip = levelMusic;
            musicAudio.loop = true;
            musicAudio.Play();
        }
    }
}
