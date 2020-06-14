﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int whichHeart;
    public Sprite fullSprite;
    public Sprite emptySprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        int hp = 0;
        for (int i = 0; i < players.Length; ++i)
        {
            hp = players[i].GetComponent<PlayerController>().hp;
        }
        if (hp > whichHeart)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = fullSprite;
        }
        else
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = emptySprite;
        }
    }
}
