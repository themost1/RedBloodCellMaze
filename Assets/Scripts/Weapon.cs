using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public double fireDelay = 0;
    public double maxFireDelay = 0.5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)
             || Input.GetKey(KeyCode.RightArrow)
             || Input.GetKey(KeyCode.UpArrow)
             || Input.GetKey(KeyCode.DownArrow) )
        {
        	Shoot();
        }

        if (fireDelay > 0)
        {
            fireDelay -= Time.deltaTime;
        }
    }

    void Shoot() 
    {
        if (fireDelay > 0)
        {
            return;
        } else
        {
            fireDelay = maxFireDelay;
        }

        Vector3 dir = Vector3.right;
        if (Input.GetKey(KeyCode.LeftArrow))
            dir = Vector3.left;
        else if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector3.right;
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector3.up;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = Vector3.down;

        GameObject go = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Bullet bs = go.GetComponent<Bullet>();
        bs.dir = dir;
        /*
    	Debug.Log("shooting...");
    	Instantiate(bullet, firePoint.position, firePoint.rotation);
        */
    }
}
