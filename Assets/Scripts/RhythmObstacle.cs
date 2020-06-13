using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmObstacle : MonoBehaviour
{
    public float timeAlive = 0;
    public float timeCutoff = 2;
    public AudioSource heartbeat;
    public Sprite safeSprite;
    public Sprite deadlySprite;
    public string state = "safe";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void toggleState()
    {
 
            
        if (state == "safe")
        {
            state = "deadly";
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = deadlySprite;
        } else
        {
            state = "safe";
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = safeSprite;
        }
    }
}
