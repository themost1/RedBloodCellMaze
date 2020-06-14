using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 5;
	public Rigidbody2D rb;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = speed * transform.right; //transform.forward?
    }

    void OnTriggerEnter2D(Collider2D collider) {
    	Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);
    	if (collider.gameObject.CompareTag("Obstacle"))
    	{
            Debug.Log("shot " + collider.name);
    		Destroy(collider);
    	}
    }
}
