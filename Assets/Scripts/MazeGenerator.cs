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

        divideMaze(0, 0, mazeSize - 1, mazeSize - 1, -100, -100);

        for (int i = 0; i < mazeSize; ++i)
        {
            for (int j = 0; j < mazeSize; ++j)
            {
                if (maze[i][j] == 1)
                {
                    Instantiate(wallBlock, new Vector3(size.x * j, size.y * i, 0), Quaternion.identity);

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

    // x1, y1 and x2, y2 are top-right and bottom-left corners of open space to divide
    void divideMaze(int x1, int y1, int x2, int y2, int xPivot, int yPivot)
    {
        if (Mathf.Abs(y2- y1) <= 1 || Mathf.Abs(x2 - x1) <= 1)
        {
            return;
        }
        print(x1 + " " + y1 + " " + x2 + " " + y2);
        int dir = Random.Range(0, 2);
        int loc = 0;
        int remove = 0;
        if (dir == 0)
        {
            loc = Random.Range(x1 + 1, x2);
            remove = Random.Range(y1, y2 + 1);

            for (int i = y1; i <= y2; ++i)
            {
                if (i != remove)
                {
                    maze[i][loc] = 1;
                }
            }

            divideMaze(x1, y1, loc - 1, y2, -1, -1);
            divideMaze(loc + 1, y1, x2, y2, -1, -1);
        }
        else
        {
            loc = Random.Range(y1 + 1, y2);
            remove = Random.Range(x1, x2 + 1);

            for (int i = x1; i <= x2; ++i)
            {
                if (i != remove)
                {
                    maze[loc][i] = 1;
                }
            }

            divideMaze(x1, y1, x2, loc - 1, -1, -1);
            divideMaze(x1, loc + 1, x2, y2, -1, -1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
