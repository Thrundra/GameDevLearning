using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDamageDealer : MonoBehaviour
{
    [SerializeField] int baseDamage = 100;

    [SerializeField] float v_DurationOfExplosion = 1f;
    [SerializeField] AudioClip a_DamageDealerAudioClip;
    AudioSource a_DamageDealerAudioSource;

    private void Start()
    {
        a_DamageDealerAudioSource = GetComponent<AudioSource>();
    }

    public int GetDamage()
    {
        return baseDamage;
    }

    public void DestoryOnHit()
    {
        string m_tagText = gameObject.tag;
        PlayDamageAudio();
        Destroy(gameObject,0.2f);
    }

    public void PlayDamageAudio()
    {
        a_DamageDealerAudioSource.PlayOneShot(a_DamageDealerAudioClip);
    }
}
