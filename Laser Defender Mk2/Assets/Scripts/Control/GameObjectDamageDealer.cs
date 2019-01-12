using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDamageDealer : MonoBehaviour
{
    [SerializeField] int baseDamage = 100;

    public int GetDamage()
    {
        return baseDamage;
    }

    public void DestoryOnHit()
    {
        Destroy(gameObject);
    }
}
