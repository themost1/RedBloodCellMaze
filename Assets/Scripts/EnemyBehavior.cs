using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private float[][] dirs = new float[][] {
    	new float[] {0, 1}, 
    	new float[] {0, -1}, 
    	new float[] {1, 0}, 
    	new float[]{-1, 0}
    };
    private int curr = 0;
    public int speed = 20;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
    	transform.position += speed * Time.deltaTime * new Vector3(dirs[curr][0], dirs[curr][1], 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            curr = (curr + 1) % dirs.Length;
        }
    }
}
