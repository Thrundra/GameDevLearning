using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    // Script Config Information
    [SerializeField] AudioClip audioClip;
    [SerializeField] GameObject blockSparklesVFX;
    //[SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    // Cached Reference
    LevelManager level;
    //   GameStatus gameStatus;

    // State Variables
    [SerializeField] int timesHit;  // TODO only serialised for debug purposes.

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<LevelManager>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("BLOCK SPRITE IS MISSING FROM ARRAY:" + gameObject.name);
        }
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
