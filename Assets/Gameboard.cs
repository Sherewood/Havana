using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
 
public class Gameboard : MonoBehaviour
{
    public Tiles tiles;
    public Tiles[,] board;
    int scale = 11;
    // Start is called before the first frame update
    void Start()
    {
        
        board = new Tiles[11,11];
        Initialize();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initialize()
    {
        board = new Tiles[11, 11];
        for (int y =0; y <scale; y++)
        {
            for (int x=0; x < scale; x++)
            {
                board[x, y] = Instantiate<Tiles>(tiles, GameObject.Find("GameBoard").transform);
                board[x, y].name = "Tile  Column " + y + " Row " + x;
                Debug.Log(board[x, y].name);
            }
        }
        giveNeighbors();
        BuildBoard();
    }
    public void giveNeighbors()
    {
        {
            for (int y = 0; y < scale; y++)
            {
                for (int x = 0; x < scale; x++)
                {
                    Tiles[] potential_neighbors = new Tiles[6];
                    if (x-1 >=0)
                    {
                        Debug.Log(x + " A " + y);
                        potential_neighbors[0] = board[x - 1, y];
                    }
                    if (x + 1 < scale)
                    {
                        Debug.Log(x + "  B " + y);
                        potential_neighbors[1] = board[x + 1, y];
                    }
                    if (y-1 >= 0)
                    {
                        Debug.Log(x + " C " + y);
                        potential_neighbors[2] = board[x, y-1];
                    }
                    if (y + 1 < scale)
                    {
                        potential_neighbors[3] = board[x, y + 1];
                    }
                    if (y+1 <scale && x-1 >=0)
                    {
                        Debug.Log(x + " G " + y);
                        potential_neighbors[4] = board[x-1, y + 1];
                    }
                    if ((y-1 >=0 &&y - 1 < scale) && (x + 1 >= 0 && x+1 < scale))
                    {
                        float t = x + 1;
                        float b = y - 1;
                        Debug.Log(t + " "  +" H "+ b);
                        potential_neighbors[5] = board[x + 1, y - 1];
                    }
                    board[x, y].neighbors=potential_neighbors;
                }
            }
        }
    }
    void BuildBoard()
    {
        for (int y = 0; y < scale; y++)
        {
            for (int x = 0; x < scale; x++)
            {
                Tiles new_tile = board[x, y];
                new_tile.transform.position = new Vector3(x, y, 0);
            }
        }
    }
}

