using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject wallBlock;
    public GameObject rhythmObstacle;
    public List<List<int>> maze = new List<List<int>>();
    public int mazeSize = 20;
    public List<int> pivotsX = new List<int>();
    public List<int> pivotsY = new List<int>();
    public GameObject enemy;
    public GameObject background;
    public GameObject trapdoor;
    public GameObject heartPickup;
    public GameObject shieldPickup;

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

        for (int i = 0; i < pivotsX.Count; ++i)
        {
            clearPivot(pivotsX[i], pivotsY[i]);
        }

        for (int i = 0; i < mazeSize; ++i)
        {
            for (int j = 0; j < mazeSize; ++j)
            {
                if (maze[i][j] == 1)
                {
                    Instantiate(wallBlock, new Vector3(size.x * j, size.y * i, 0), Quaternion.identity);

                }
                else if ((i & j) % 3 == 1)
                {
                    Instantiate(trapdoor, new Vector3(size.x * j, size.y * i, 0), Quaternion.identity);
                } else
                {
                    if (Random.Range(0, 5) == 1)
                        Instantiate(enemy, new Vector3(size.x * j + size.x / 2, size.y * i + size.y / 2, -1), Quaternion.identity);
                    else if (Random.Range(0, 40) == 1)
                        Instantiate(heartPickup, new Vector3(size.x * j, size.y * i, 0), Quaternion.identity);
                    else if (Random.Range(0, 80) == 1)
                        Instantiate(shieldPickup, new Vector3(size.x * j, size.y * i, 0), Quaternion.identity);
                }

                Instantiate(background, new Vector3(size.x * j, size.y * i, 10), Quaternion.identity);
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

    void clearPivot(int xloc, int yloc)
    {
        if (yloc < 1 || yloc > mazeSize - 2 || xloc < 1 || xloc > mazeSize - 2)
        {
            print("issue: " + xloc + " " + yloc);
            return;
        }
        if (maze[yloc][xloc-1] == 0)
        {
            maze[yloc][xloc + 1] = 0;
        }
        if (maze[yloc][xloc + 1] == 0)
        {
            maze[yloc][xloc - 1] = 0;
        }
        if (maze[yloc-1][xloc] == 0)
        {
            maze[yloc+1][xloc] = 0;
        }
        if (maze[yloc+1][xloc] == 0)
        {
            maze[yloc-1][xloc] = 0;
        }
    }

    // x1, y1 and x2, y2 are top-right and bottom-left corners of open space to divide
    void divideMaze(int x1, int y1, int x2, int y2, int xPivot, int yPivot)
    {
        if (Mathf.Abs(y2- y1) <= 1 || Mathf.Abs(x2 - x1) <= 1)
        {
            return;
        }
        int dir = Random.Range(0, 2);
        int loc = 0;
        int remove = 0;
        int iterations = 0;
        if (dir == 0)
        {
            loc = Random.Range(x1 + 1, x2);
            while (loc == xPivot && iterations < 100)
            {
                loc = Random.Range(x1 + 1, x2);
                iterations++;
            }

            if (iterations >= 100) return;

            remove = Random.Range(y1, y2 + 1);

            for (int i = y1; i <= y2; ++i)
            {
                if (i != remove)
                {
                    if (!adjacentToPivot(loc, i))
                    {
                        maze[i][loc] = 1;
                    }
                  
                }
            }

            pivotsX.Add(loc);
            pivotsY.Add(remove);

            divideMaze(x1, y1, loc - 1, y2,loc, remove);
            divideMaze(loc + 1, y1, x2, y2, loc, remove);

           
        }
        else
        {
            loc = Random.Range(y1 + 1, y2);
            while (loc == yPivot && iterations < 100)
            {
                loc = Random.Range(y1 + 1, y2);
                iterations++;
            }

            if (iterations >= 100) return;
            remove = Random.Range(x1, x2 + 1);

            for (int i = x1; i <= x2; ++i)
            {
                if (i != remove)
                {
                    if (!adjacentToPivot(i, loc))
                    {
                        maze[loc][i] = 1;

                    }
                }
            }

            divideMaze(x1, y1, x2, loc - 1, remove, loc);
            divideMaze(x1, loc + 1, x2, y2, remove, loc);

            pivotsX.Add(remove);
            pivotsY.Add(loc);
        }
    }

    bool adjacentToPivot(int x, int y)
    {
        for (int i = 0; i < pivotsX.Count; ++i)
        {
            if (pivotsX[i] == x && Mathf.Abs(pivotsY[i] - y) <= 1) {
                return true;
            }
            if (Mathf.Abs(pivotsX[i] - x) <= 1 && pivotsY[i] == y)
            {
                return true;
            }
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
