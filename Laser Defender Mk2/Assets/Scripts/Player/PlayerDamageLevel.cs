using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageLevel : MonoBehaviour
{
    [SerializeField] public Sprite[] m_PlayerDamageLevels;
    [SerializeField] GameObject m_SmokeParticleEffect;

    private List<GameObject> l_ListOfSmokeEffects;

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

    public GameObject GetSmokeParticleEffect(Vector3 playerShipPosition, int levelOfDamage)
    {
        Vector3 playerPosition = playerShipPosition;
        if(levelOfDamage == 1)
        {
            playerPosition.x = playerPosition.x + 0.2f;
            playerPosition.y = playerPosition.y - 0.1f;
        }
        else if(levelOfDamage == 2)
        {
            playerPosition.x = playerPosition.x - 0.25f;
            playerPosition.y = playerPosition.y + 0.00f;
        }

        Vector3 particlePosition = m_SmokeParticleEffect.transform.position;
        particlePosition = playerPosition;
        m_SmokeParticleEffect.transform.position = particlePosition;

        return m_SmokeParticleEffect;
    }    
}
