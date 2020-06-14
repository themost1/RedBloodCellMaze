using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 10;
    public Vector3 dir = Vector3.right;
	public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = speed * dir; //transform.forward?
    }

    void OnTriggerEnter2D(Collider2D collider) {
    	if (collider.gameObject.CompareTag("Enemy"))
    	{
            Destroy(gameObject);
        	Destroy(collider.gameObject);
    	} else if (collider.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
