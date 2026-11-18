using System;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    public int Width = 20;
    public int Height = 20;
    public GameObject GOFSlab;
    [Range(0.1f,5f)]
    public float TimeStep = 1f;

    public bool RunSim = false;

    enum CellState
    {
        DEAD,
        ALIVE
    }

    private CellState[,] CellGrid;
    //private CellState[,,] CellGrid; A 3d cell grid with 2 different layers
    //private CellState[,] CellGridNext; another grid to save the next state and be able to switch. 
    private GOFCell[,] SlabGrid;

    private float TimeAccu =0f;
    private void Awake()
    {
        CellGrid = new CellState[Width, Height]; //create the grid
         for(int i = 0;  i < Width; i++)
        {
            for(int j = 0;  j < Height; j++)
            {
                CellGrid[i,j] = CellState.DEAD; //set all cells as dead
            }
        }
        //just test some cells and set them alive
        CellGrid[10,10] = CellState.ALIVE;
        CellGrid[10,11] = CellState.ALIVE;
        CellGrid[10,12] = CellState.ALIVE;
       
        SlabGrid = new GOFCell[Width, Height]; //creates slabgrid

        for(int i = 0;  i < Width; i++)
        {
            for(int j = 0;  j < Height; j++)
            {
                Vector3 position = Vector3.right * i + Vector3.up * j;
                position.x += 0.5f;
                position.y += 0.5f;
                GameObject gobj = Instantiate(GOFSlab, position, Quaternion.identity);
                //gobj.GetComponent<GOFCell>().SetAlive();
                SlabGrid[i,j] = gobj.GetComponent<GOFCell>(); //store the slab

            }
        }
    }

//construct the game board
    void Start()
    {
       UpdateBoard();
    }

    private void UpdateBoard()
    {
         for(int i = 0;  i < Width; i++)
        {
            for(int j = 0;  j < Height; j++)
            {
                if (CellGrid[i,j] == CellState.DEAD)
                    SlabGrid[i,j].SetDead();
                else
                    SlabGrid[i,j].SetAlive();
                

            }
        }
    }

    private int CountAliveCells(int x, int y)
    {
        int count = 0;
        for (int i = x-1; i <= x+1; i++)
        {
            for(int j = y-1; j<=y+1;j++)
            {
                if((i== x && j== y)|| i<0 || j<0 || i >= Width || j>= Height) continue;

                if(CellGrid[i,j] == CellState.ALIVE) count++;

            }
        }
        return count;
    }

    private void LogicUpdate()
    {
        //g through the whole board (cellGrid)
        for(int i = 0;  i < Width; i++)
        {
            for(int j = 0;  j < Height; j++)
            {
                int count = CountAliveCells(i,j);
                if(CellGrid[i,j] == CellState.ALIVE)
                {
                    //1.rule: less than 2 cells around == dies
                    if(count < 2) CellGrid[i,j] = CellState.DEAD;
                    //2.rule. more than 3 == dead
                    else if (count > 3) CellGrid[i,j] = CellState.DEAD;
                    //3.rule: 2 or 3 around then live
                }
                else
                {
                    //4.rule: exactly 3 live cells around -> alive
                    if(count == 3) CellGrid[i,j] = CellState.ALIVE;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!RunSim) return;
        TimeAccu += Time.deltaTime;
        if(TimeAccu >= TimeStep)
        {
            //game logic update
            LogicUpdate();

            //game render update
            UpdateBoard();

            TimeAccu = 0;
        }
    }
}
