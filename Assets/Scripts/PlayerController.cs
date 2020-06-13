﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
	public float speed = 20;
    public int hp = 3;
    public TextMeshProUGUI WinText;

    private int points;
    private int StatusAlive;
    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        SetPointsText ();
        WinText.text = "";
        StatusAlive = 1;
        facingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
    	float xDir = Input.GetAxis("Horizontal");
    	float yDir = Input.GetAxis("Vertical");
    	transform.position += speed * Time.deltaTime * new Vector3(xDir, yDir, 0f);
        Debug.Log("transforms: xDir " + yDir + " " + transform.position);

        bool flip = (facingRight && xDir < 0) || (!facingRight && xDir >= 0);
        facingRight = xDir >= 0;
        transform.Rotate(0f, flip ? 180f : 0f, 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StatusAlive = 0;
            Debug.Log("uh oh...");
        }
        else if (collision.gameObject.CompareTag("Prize"))
        {
            points = points + 1;
            Debug.Log("points +1");
        }
    }

    void SetPointsText()
    {
        // SetPointsText.text = "Points: " + points.ToString ();
        if (StatusAlive == 0){
            WinText.text = "You died";
        }
        if (points >= 10){
            WinText.text = "You won";
        }

    }

}