using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    private bool isOpen;
    private float elapsedTime;
    private Collider2D collider;
    public float delay = 5;
	public Sprite openSprite;
	public Sprite closedSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        elapsedTime = 0;
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    	elapsedTime += Time.deltaTime;
    	if (elapsedTime > delay) {
    		isOpen = !isOpen;
    		ToggleValve();
    		elapsedTime = 0;
    	}
    }

    void ToggleValve() {
    	SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = isOpen ? openSprite : closedSprite;
    
        collider.enabled = !isOpen;
    }
}
