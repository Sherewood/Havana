using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game_Master : MonoBehaviour
{
    [SerializeField]
    Vector2Int boardSize = new Vector2Int(11, 11);

    [SerializeField]
    public Gameboard board = default;
    public Player player;
    public int num_players = 2;
    public Player[] players;
    private Color[] PlayerColor;
    public TextMeshProUGUI playerText;
    public bool start = true;
    public (bool,List<Tiles>) win = (false,new List<Tiles>());
    public bool game = false;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Initilize(0.01f));
        //board.Initialize();
        PlayerColor = new Color[] { Color.red, Color.blue, Color.green, Color.black };
        AllocatePlayers(num_players);
        player.Active = false;



    }
    void AllocatePlayers(int numberOf)
    {
        players = new Player[numberOf];
        for (int i = 0; i < numberOf; i++)
        {
            
            players[i] = Instantiate<Player>(player);
            players[i].player_color = PlayerColor[i];

            players[i].Active = false;
            players[i].name = player.name+" "+  i;
        }
        players[0].Active = true;
      //  players[1].AI = true;

    }
    public Color SetColor()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].Active)
            {
               
                return players[i].player_color;

            }
        }
        return Color.black;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            start = false;
            game = true;
        }

        if (game)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].Active)
                {
                    playerText.text = players[i] + "It is now your turn";
                }


            }
            
            if (win.Item1)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i].Active)
                    {
                        playerText.text = players[i] + "Congraturaisins! You are winner";
                        game = false;
                        StartCoroutine(Flourish(win.Item2, 0.5f));

                    }


                }
            }
        }

    }
    void OnValidate()
    {
        if (boardSize.x < 2)
        {
            boardSize.x = 2;
        }
        if (boardSize.y < 2)
        {
            boardSize.y = 2;
        }
    }
    public void SwapPlayers()
    {
        bool swap = false;
        win = board.CheckWin();
        int position = 0;
        if(!win.Item1)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].Active)
                {
                    players[i].Active = false;
                    position = i;
                    break;
                }

            }
            if (position + 1 < players.Length) { players[position + 1].Active = true; }
            else if (position + 1 >= players.Length) players[0].Active = true;
        }

        
    }
    private IEnumerator Initilize (float WaitTime)
    {
       
        yield return new WaitForSeconds(WaitTime);
        board.Initialize();
    }
    private IEnumerator Flourish(List<Tiles> final, float WaitTime)
    {

        yield return new WaitForSeconds(WaitTime);
        foreach (Tiles i in final)
        {
            
            yield return new WaitForSeconds(WaitTime);
            i.GetComponentInChildren<MeshRenderer>().material.EnableKeyword("_EMISSION");
        }

    }

}
