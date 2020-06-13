using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 5;
	public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = speed * transform.forward; //transform.forward?
    }

    void OnTriggerEnter2D(Collider2D collider) {
    	Destroy(gameObject);
    	if (collider.gameObject.CompareTag("Obstacle"))
    	{
            Debug.Log("shot " + collider.name);
    		Destroy(collider);
    	}
    }
}
