using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioCatalog : MonoBehaviour
{
    [SerializeField] AudioClip[] backgroundAudioSounds;
    AudioSource a_EffectAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        a_EffectAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudioSource(string objectTag)
    {
        if (objectTag == "DamageDebris")
        {
            a_EffectAudioSource.PlayOneShot(backgroundAudioSounds[0]);
        }
    }
}
