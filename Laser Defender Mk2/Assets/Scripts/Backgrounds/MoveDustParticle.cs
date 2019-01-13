using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDustParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveParticleWithObject();
    }

    private void MoveParticleWithObject()
    {
        Vector3 m_NewLoction = GetComponent<BackgroundDebrisMove>().GetPosition();

        transform.position = m_NewLoction;
    }
}
