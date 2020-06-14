using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour
{
    public string state = "safe";
    public bool becomingDeadly = false;
    public double deadlyCounter = 0.5;
    public Sprite safeSprite;
    public Sprite deadlySprite;
    public bool playerOn = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (becomingDeadly)
        {
            deadlyCounter -= Time.deltaTime;
            if (deadlyCounter < 0)
            {
                if (state == "safe")
                {
                    state = "deadly";
                    deadlyCounter = 1;
                }
                else
                {
                    state = "safe";
                    deadlyCounter = 0.8;
                    becomingDeadly = false;
                }
            }
        }

        if (state == "deadly")
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = deadlySprite;
            if (playerOn)
            {
                player.GetComponent<PlayerController>().takeDamage();
            }
        }
        else
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = safeSprite;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerOn = true;
            player = collider.gameObject;
            becomingDeadly = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerOn = false;
        }
    }
}
