using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageLevel : MonoBehaviour
{
    [SerializeField] Sprite[] m_PlayerDamageLevels;
    [SerializeField] GameObject parent;
    float Fixescale = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(Fixescale / parent.transform.localScale.x, Fixescale / parent.transform.localScale.y, 0);
    }
}
