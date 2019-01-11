using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageLevel : MonoBehaviour
{
    [SerializeField] public Sprite[] m_PlayerDamageLevels;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Sprite GetSprite(int m_SpriteArrayValue)
    {
        return m_PlayerDamageLevels[m_SpriteArrayValue];
    }
}
