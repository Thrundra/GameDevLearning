using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float m_backgroundScrollSpeed = 0.01f;
    Material m_myMaterial;
    Vector2 v_Offset;
    // Start is called before the first frame update
    void Start()
    {
        m_myMaterial = GetComponent<Renderer>().material;
        v_Offset = new Vector2(0, m_backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        m_myMaterial.mainTextureOffset += v_Offset * Time.deltaTime;
    }
}
