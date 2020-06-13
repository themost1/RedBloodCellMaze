using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject wallBlock;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 size = wallBlock.GetComponent<BoxCollider2D>().size;
        print(size.x);
        print(size.y);

        for (int i = 0; i < 10; ++i)
        {
            Instantiate(wallBlock, new Vector3(size.x * i, size.y * i, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
