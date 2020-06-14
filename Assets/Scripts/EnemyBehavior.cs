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
    public float oldx = 0, oldy = 0;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if (transform.position.x == oldx && transform.position.y == oldy)
        {
            curr = (curr + 1) % dirs.Length;
        }
        oldx = transform.position.x;
        oldy = transform.position.y;

    	transform.position += speed * Time.deltaTime * new Vector3(dirs[curr][0], dirs[curr][1], 0f);

        int changeDir = Random.Range(0, (int)(1000 * Time.deltaTime));
        if (changeDir == 1)
        {
            curr = (curr + 1) % dirs.Length;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            curr = (curr + 1) % dirs.Length;
        }
    }
}
