using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public int whichShield;
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
        int shields = 0;
        for (int i = 0; i < players.Length; ++i)
        {
            shields = players[i].GetComponent<PlayerController>().shieldsLeft;
        }
        if (shields > whichShield)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
