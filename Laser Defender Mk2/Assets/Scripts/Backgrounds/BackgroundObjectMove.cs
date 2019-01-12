using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjectMove : MonoBehaviour
{
    [SerializeField] SceneObjectWaveConfig c_WaveConfig;
    float m_RandomRotationDirection;
    SpriteRenderer c_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        ScaleBackgroundObject();
        c_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_RandomRotationDirection = Random.Range(-9.0f, 9.0f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveBackgroundObject();
    }

    private void ScaleBackgroundObject()
    {
        float r_RandomScale = Random.Range(2.5f, 5.5f);
        transform.localScale = new Vector3( r_RandomScale, r_RandomScale);
    }

    public void SetWaveConfig(SceneObjectWaveConfig config)
    {
        this.c_WaveConfig = config;
    }

    private void MoveBackgroundObject()
    {
        Transform m_EndLocation = c_WaveConfig.GetEndingWaypoint();
        var m_MoveThisFrame = c_WaveConfig.GetBackgroundObjectSpeed() * Time.deltaTime;

        // Get the end X position based upon their current X position.
        Vector3 endPosition = m_EndLocation.position;
        float xPosition = this.transform.position.x;
        endPosition.x = xPosition;
        m_EndLocation.position = endPosition;

        // Move towards the end point.
        transform.position = Vector3.MoveTowards(transform.position, endPosition, m_MoveThisFrame);

        // Rotate the background object
        transform.Rotate(0, 0, Time.deltaTime * m_RandomRotationDirection);

        // If the object reaches the end point, destroy the object
        if(transform.position.y == m_EndLocation.position.y)
        {
            Destroy(gameObject);
        }
    }
}
