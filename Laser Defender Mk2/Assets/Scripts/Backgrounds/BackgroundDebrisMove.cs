using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDebrisMove : MonoBehaviour
{
    [SerializeField] SceneObjectWaveConfig c_WaveConfig;
    float m_RandomRotationDirection;
    SpriteRenderer c_SpritRenderer;
    // Start is called before the first frame update
    void Start()
    {
        c_SpritRenderer = GetComponent<SpriteRenderer>();
        m_RandomRotationDirection = Random.Range(-15.0f, 15.0f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveBackgroundDebrisObject();
    }

    private void MoveBackgroundDebrisObject()
    {
        Transform m_EndLocation = c_WaveConfig.GetEndingWaypoint();
        var m_MoveThisFrame = c_WaveConfig.GetBackgroundObjectSpeed() * Time.deltaTime;

        Vector3 endPostion = m_EndLocation.position;
        float xPosition = this.transform.position.x;
        endPostion.x = xPosition;
        m_EndLocation.position = endPostion;

        transform.position = Vector3.MoveTowards(transform.position, endPostion, m_MoveThisFrame);

        transform.Rotate(0, 0, Time.deltaTime * m_RandomRotationDirection);

        if(transform.position.y == m_EndLocation.position.y)
        {
            Destroy(gameObject);
        }
    }
}
