using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    // Script Config Information
    [SerializeField] AudioClip audioClip;

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
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
