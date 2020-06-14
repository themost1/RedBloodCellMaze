using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)
             || Input.GetKeyDown(KeyCode.RightArrow)
             || Input.GetKeyDown(KeyCode.UpArrow)
             || Input.GetKeyDown(KeyCode.DownArrow) )
        {
        	Shoot();
        }
    }

    void Shoot() 
    {
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
