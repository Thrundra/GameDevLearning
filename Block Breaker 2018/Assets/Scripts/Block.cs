using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    // Script Config Information
    [SerializeField] AudioClip audioClip;
    [SerializeField] GameObject blockSparklesVFX;

    // Cached Reference
    LevelManager level;
    GameStatus gameStatus;

    private void Start()
    {
        level = FindObjectOfType<LevelManager>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        level.BlockDestroyed();
        PlayBlockDestroySFX();
        TriggerSparklesVFX();
        Destroy(gameObject);
    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
