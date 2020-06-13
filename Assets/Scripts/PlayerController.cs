﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
    	float xDir = Input.GetAxis("Horizontal");
    	float yDir = Input.GetAxis("Vertical");
    	transform.position += speed * Time.deltaTime * new Vector3(xDir, yDir, 0f);
        Debug.Log(xDir + " " + yDir + " " + transform.position);
    	transform.Rotate(yDir * 180, xDir * 180, 0f); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("uh oh...");
        }
    }

}
