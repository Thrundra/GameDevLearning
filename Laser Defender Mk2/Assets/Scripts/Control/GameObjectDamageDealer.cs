using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDamageDealer : MonoBehaviour
{
    [SerializeField] int baseDamage = 100;

    [SerializeField] float v_DurationOfExplosion = 1f;

    public int GetDamage()
    {
        return baseDamage;
    }

    public void DestoryOnHit()
    {
        string m_tagText = gameObject.tag;

        Destroy(gameObject);
    }
}
