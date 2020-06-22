using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakingSound;
    [SerializeField] GameObject blockExplosionVFX;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] Color[] hitColors;
    [SerializeField] int maxHP;

    [SerializeField] int timesHit; //used for debug purposes

    private int spriteCounter = 0;

    private Level level;
    enum BlockType
    {
        Unbreakable,
        Breakable
    }

    void Start()
    {
        countBreakableBlocks();
    }

    private void countBreakableBlocks() {
        level = FindObjectOfType<Level>();
        if (tag.Equals(BlockType.Breakable.ToString())) {
            level.CountBlocks();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag.Equals(BlockType.Breakable.ToString())) {
            handleHit();
        } else if (tag.Equals(BlockType.Unbreakable.ToString())) {
            //do nothing
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
    }

    private void handleHit() {
        timesHit++;
        if (timesHit >= maxHP) {
            destroyBlock();
        } else {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteCounter];
            Color newColor = hitColors[spriteCounter]; //workaround 
            this.GetComponent<SpriteRenderer>().color = new Color(newColor.r, newColor.g, newColor.b); //new Color(1f,0.30196078f, 0.30196078f);
            spriteCounter++;
        }
    }

    private void destroyBlock(){
        AudioSource.PlayClipAtPoint(breakingSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.DestroyBreakableBlock();
        FindObjectOfType<GameSession>().AddToScore();
        triggerBlockExplosionVFX();
    
    }

    private void triggerBlockExplosionVFX() {
        GameObject explosion = Instantiate(blockExplosionVFX, transform.position, transform.rotation);
        Destroy(explosion, 1f);
    }
}
