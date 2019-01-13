using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Playlist")]
public class MusicPlaylist : ScriptableObject
{
    [SerializeField] AudioClip[] a_ListOfSoundTracksToPlay;

    public AudioClip GetSoundTrackAudioClip(int valueInPlaylist)
    {
        return a_ListOfSoundTracksToPlay[valueInPlaylist];
    }
}
