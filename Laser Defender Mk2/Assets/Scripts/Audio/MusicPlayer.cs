using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    AudioSource a_MusicPlayer;
    AudioClip a_MusicTrackToPlay;
    [SerializeField] MusicPlaylist m_MusicPlaylist;
    int m_SceneBuildValue;

    private void Awake()
    {
        SetUpSingleton();
        a_MusicPlayer = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneWasLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneWasLoaded;
    }

    private void SetUpSingleton()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject); ;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnSceneWasLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        int m_SceneIndex = scene.buildIndex;

        switch (m_SceneIndex)
        {
            case 0:
                a_MusicTrackToPlay = m_MusicPlaylist.GetSoundTrackAudioClip(0);
                break;
            case 2:
                a_MusicTrackToPlay = m_MusicPlaylist.GetSoundTrackAudioClip(1);
                break;
        }

        a_MusicPlayer.clip = a_MusicTrackToPlay;
        a_MusicPlayer.loop = true;
        a_MusicPlayer.Play();
    }

    private void PlayRequiredAudioTrack(int sceneIndex)
    {
        switch(sceneIndex)
        {
            case 0: a_MusicTrackToPlay = m_MusicPlaylist.GetSoundTrackAudioClip(0);
                break;
            case 1: a_MusicTrackToPlay = m_MusicPlaylist.GetSoundTrackAudioClip(1);
                break;
        }

        a_MusicPlayer.clip = a_MusicTrackToPlay;
        a_MusicPlayer.loop = true;
        a_MusicPlayer.Play();
    }

    
}
