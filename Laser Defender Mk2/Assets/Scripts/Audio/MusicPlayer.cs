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
    }

    // Start is called before the first frame update
    void Start()
    {
        a_MusicPlayer = GetComponent<AudioSource>();
        m_SceneBuildValue = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(m_SceneBuildValue);
        PlayRequiredAudioTrack(m_SceneBuildValue);
    }

    // Update is called once per frame
    void Update()
    {
        
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
