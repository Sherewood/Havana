using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class Gameboard : MonoBehaviour
{
    public Tiles tiles;
    public Tiles[,] board;
    int scale = 20;
    public int Base = 3;
    private bool done = false;
    // Start is called before the first frame update
    void Start()
    {

        board = new Tiles[scale, scale];



    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Initialize()
    {
        board = new Tiles[scale, scale];
        for (int y = 0; y < scale; y++)
        {
            for (int x = 0; x < scale; x++)
            {
                board[x, y] = Instantiate<Tiles>(tiles, GameObject.Find("GameBoard").transform);
                board[x, y].name = "Tile Column " + y + " Row " + x;

            }
        }

        BuildBoard();
        giveNeighbors();
    }
    public void giveNeighbors()
    {

        int lenght = (2 * Base) / 2;
        int counter = Base;
        for (int y = 0; y < (2 * Base); y++)
        {

            for (int x = 0; x < counter; x++)
            {

                if (y < lenght)
                {

                    if (x - 1 >= 0)
                    {

                        if (board[x - 1, y].drawn) board[x, y].neighbors.Add(board[x - 1, y]);//.Append(board[x - 1, y]);
                    }
                    if (x + 1 < scale)
                    {

                        if (board[x + 1, y].drawn) board[x, y].neighbors.Add(board[x + 1, y]);
                    }
                    if (y - 1 >= 0)
                    {

                        if (board[x, y - 1].drawn) board[x, y].neighbors.Add(board[x, y - 1]);
                    }
                    if (y + 1 < scale)
                    {
                        if (board[x, y + 1].drawn) board[x, y].neighbors.Add(board[x, y + 1]);
                    }
                    if ((x + 1 < scale && y + 1 < scale))
                    {
                        if (board[x + 1, y + 1].drawn) board[x, y].neighbors.Add(board[x + 1, y + 1]);
                    }
                    if ((x - 1 >= 0 && y - 1 >= 0))
                    {
                        if (board[x - 1, y - 1].drawn) board[x, y].neighbors.Add(board[x - 1, y - 1]);
                    }
                }
                else if (y == lenght)
                {


                    if (x - 1 >= 0)
                    {

                        if (board[x - 1, y].drawn) board[x, y].neighbors.Add(board[x - 1, y]);//.Append(board[x - 1, y]);
                    }
                    if (x + 1 < scale)
                    {

                        if (board[x + 1, y].drawn) board[x, y].neighbors.Add(board[x + 1, y]);
                    }
                    if (y - 1 >= 0)
                    {
                        if (board[x, y].drawn) { }
                        board[x, y].neighbors.Add(board[x, y - 1]);
                    }
                    if (y + 1 < scale)
                    {
                        if (board[x, y + 1].drawn) board[x, y].neighbors.Add(board[x, y + 1]);
                    }

                    if ((x - 1 >= 0 && y - 1 >= 0))
                    {
                        if (board[x - 1, y - 1].drawn) board[x, y].neighbors.Add(board[x - 1, y - 1]);
                    }
                    if ((x - 1 >= 0 && y + 1 < scale))
                    {

                        if (board[x - 1, y + 1].drawn) board[x, y].neighbors.Add(board[x - 1, y + 1]);
                    }
                }
                else if (y > lenght)
                {

                    if (x - 1 >= 0)
                    {

                        if (board[x - 1, y].drawn) board[x, y].neighbors.Add(board[x - 1, y]);//.Append(board[x - 1, y]);
                    }
                    if (x + 1 < scale)
                    {

                        if (board[x + 1, y].drawn) board[x, y].neighbors.Add(board[x + 1, y]);
                    }
                    if (y - 1 >= 0)
                    {

                        if (board[x, y - 1].drawn) board[x, y].neighbors.Add(board[x, y - 1]);
                    }
                    if (y + 1 < scale)
                    {
                        if (board[x, y + 1].drawn) board[x, y].neighbors.Add(board[x, y + 1]);
                    }
                    if ((x - 1 >= 0 && y + 1 < scale))
                    {

                        if (board[x - 1, y + 1].drawn) board[x, y].neighbors.Add(board[x - 1, y + 1]);
                    }
                    if ((x + 1 < scale && y - 1 >= 0))
                    {

                        if (board[x + 1, y - 1].drawn) board[x, y].neighbors.Add(board[x + 1, y - 1]);
                    }
                }

            }
            if (y < lenght)
            {
                counter++;


            }
            else
            {
                counter--;


            }
        }
    }


    void BuildBoard()
    {



        Vector3 nxtPos = new Vector3(0, 2 * Base, 0);
        int counter = Base;
        int halfway = scale / 2;
        int length = 2 * Base;
        int inflection = length / 2;
        if (length >= board.GetLength(0))
        {

            length = Base;
            inflection = Base / 2;
        }
        //point where the hex begins to decrease
        for (int y = 0; y <= length; y++)
        {
            float resetx = nxtPos.x;
            float resety = nxtPos.y;
            for (int x = 0; x <= counter; x++)
            {

                int interval = x;//halfway + (counter / 2) - (x);                 
                Tiles new_tile = board[(interval), y];
                //hardcoding in "corners" and "edges" Tiles which represent the end of the board 
                if (y == 0) // first edge of 1 + 2 corners 
                {
                    if (x == 0 || x == counter)
                    {
                        board[interval, y].corner = true;
                    }
                    else
                    {
                        board[interval, y].edge = (true, 1);

                    }
                }
                else if (y < inflection) //edges 2 and 6 (opposite sides of the cube
                {
                    if (x == 0) board[interval, y].edge = (true, 2);
                    else if (x == counter) board[interval, y].edge = (true, 6);
                }
                else if (y == inflection) //2 corners 
                {
                    if (x == 0 || x == counter)
                    {
                        board[interval, y].corner = true;
                    }
                }
                else if (y > inflection && y < length) //edges 3 and 5
                {
                    if (x == 0) board[interval, y].edge = (true, 3);
                    else if (x == counter) board[interval, y].edge = (true, 5);
                }
                else
                {
                    if (x == 0 || x == counter)
                    {
                        board[interval, y].corner = true;
                    }
                    else
                    {
                        board[interval, y].edge = (true, 4);

                    }
                }
                board[(interval), y].drawn = true;
                new_tile.transform.position = nxtPos;
                nxtPos.x += 1.25f;

            }
            if (y < inflection)
            {
                counter++;

                nxtPos.x = (resetx - .5f);
            }
            else
            {
                counter--;

                nxtPos.x = resetx + .5f;
            }
            nxtPos.y -= (float)1;


        }

    }
    public (bool, List<Tiles>) CheckWin()
    {

        List<Tiles> fork;
        (bool, List<Tiles>) ring;
        for (int y = 0; y < board.GetLength(1); y++)
        {

            for (int x = 0; x < board.GetLength(0); x++)
            {

                if (board[x, y].drawn == true)
                {
                    fork = new List<Tiles>();
                    if (board[x, y].color != Color.white)
                    {
                        board[x, y].marked = true;
                        fork.Add(board[x, y]);

                        fork.Equals(CheckWin(board[x, y], fork));
                        //fork.Insert(0, board[x, y]);

                        if (isAWin(fork).Item1 && fork.Count >= 3)
                        {
                            return (true, fork);
                        }

                    }
                    else
                    {
                        ring = (false, new List<Tiles>());
                        board[x, y].marked = true;
                        ring.Item2.Add(board[x, y]);
                        ring = isARing(board[x, y], ring.Item2);

                        if (ring.Item1)
                        {
                            return (true, ring.Item2);
                        }

                    }
                }
            }
        }
        refresh();
        return (false, new List<Tiles>());
    }
    private void refresh()
    {
        for (int y = 0; y < board.GetLength(1); y++)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                board[x, y].marked = false;
            }
        }
    }
    public List<Tiles> CheckWin(Tiles tile, List<Tiles> winCon)
    {
        foreach (Tiles i in tile.neighbors)
        {


            if (i.drawn && !i.marked)
            {
                if (!GameObjectContains(i.name, winCon))
                {
                    if (i.color == tile.color)
                    {
                        i.marked = true;
                        winCon.Add(i);

                        winCon = CheckWin(i, winCon);

                    }
                }
            }
        }



        return winCon;

    }
    private bool GameObjectContains(String name, List<Tiles> list)
    {
        foreach (Tiles i in list)
        {
            if (i.name.Equals(name))
            {
                return true;
            }
        }

        return false;
    }
    private (bool, List<Tiles>) isAWin(List<Tiles> final)
    {

        int CornerCounter = 0;
        List<int> EdgeNumber = new List<int>();
        foreach (Tiles i in final)
        {
            if (i.corner)
            {
                CornerCounter++;
            }
            else if (i.edge.Item1)
            {
                if (!EdgeNumber.Contains(i.edge.Item2))
                {

                    EdgeNumber.Add(i.edge.Item2);
                }
            }
        }
        if (CornerCounter >= 2)
        {
            done = true;
            return (true, final);
        }
        else if (EdgeNumber.Count >= 3)
        {
            done = true;
            return (true, final);
        }
        else
        {
            return (false, final);
        }
    }
    private (bool, List<Tiles>) isARing(Tiles i, List<Tiles> final)
    {
        bool check = true;

        if (i.corner || i.edge.Item1)
        {
            final.Add(i);

            return (false, final);
        }
        else
        {
            foreach (Tiles neighbor in i.neighbors)
            {
                if (neighbor.color == i.color && !GameObjectContains(neighbor.name, final))
                {
                    final.Add(neighbor);

                    check = isARing(neighbor, final).Item1;
                    if (check == false) break;
                }
            }
            if (check) return (true, final);
            else return (false, final);
        }
    }

    IEnumerator Bar(System.Action<bool> callback)
    {
        yield return 1.0f;

        callback((true));
    }
}