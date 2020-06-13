using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject wallBlock;
    public List<List<int>> maze = new List<List<int>>();
    public int mazeSize = 20;

    // Start is called before the first frame update
    void Start()
    {
         for (int i = 0; i < mazeSize; ++i)
        {
            List<int> empty = new List<int>();
            for (int j = 0; j < mazeSize; ++j)
            {
                empty.Add(0);
            }

            maze.Add(empty);
        }

        Vector3 size = wallBlock.GetComponent<BoxCollider2D>().size;
    

        for (int i = 0; i < mazeSize; ++i)
        {
            for (int j = 0; j < mazeSize; ++j)
            {
                if (maze[i][j] == 1)
                {
                    Instantiate(wallBlock, new Vector3(size.x * i, size.y * j, 0), Quaternion.identity);

                }
            }
        }
        for (int i = -1; i <= mazeSize; ++i)
        {
            Instantiate(wallBlock, new Vector3(-1 * size.x, size.y * i, 0), Quaternion.identity);
            Instantiate(wallBlock, new Vector3(mazeSize * size.x, size.y * i, 0), Quaternion.identity);
            Instantiate(wallBlock, new Vector3(i * size.x, -1 * size.y, 0), Quaternion.identity);
            Instantiate(wallBlock, new Vector3(i * size.x, size.y * mazeSize, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
