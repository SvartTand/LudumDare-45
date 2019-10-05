using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type : MonoBehaviour {

    public string typeName = "Unknown";
    public string typeId;
    public Sprite sprite;
    public Sprite icon;
    public Color c;

    public ListOfTypes listOfTypes;

    public float updInterval;
    public int rigidity;
    public int weight;

    public bool burnable;

    public enum State { Solid, Liquid, Gas, Plasma, Animal};
    public State myState;


    public virtual void UpdateTile(Tile tile, Tile[] neighbours)
    {
        if (myState == State.Animal)
        {
            if(neighbours[Tile.N].type.myState != State.Gas)
            {
                //Kill animal
                tile.SetType(listOfTypes.types[0]);
            }

            if (neighbours[Tile.S].type.myState == State.Solid)
            {
                List<Tile> possibleMoves = new List<Tile>();

                for(int i = 1; i<neighbours.Length; i++)
                {
                    if (neighbours[i].type.myState == State.Gas && neighbours[i].type.typeId != "B")
                    {
                        possibleMoves.Add(neighbours[i]);

                    }else if(neighbours[i].type.myState == State.Solid && neighbours[i].type.typeId != "B")
                    {
                        if(neighbours[i].neighbours[Tile.N].type.myState == State.Gas && neighbours[i].neighbours[Tile.N] != tile)
                        {
                            possibleMoves.Add(neighbours[i].neighbours[Tile.N]);
                        }
                    }
                }

                int r = Random.Range(0, possibleMoves.Count);
                possibleMoves[r].SetType(tile.type);
                tile.SetType(listOfTypes.types[0]);

            }
            else if (neighbours[Tile.S].type.myState == State.Gas)
            {
                neighbours[Tile.S].SetType(tile.type);
                neighbours[Tile.S].direction = 0;
                tile.SetType(listOfTypes.types[0]);
                tile.direction = 0;
            }
        }

            if (myState == State.Gas)
        {
            List<int> possibleMovments = new List<int>();
            if (neighbours[Tile.N].type.myState == State.Gas && neighbours[Tile.N].type.typeId != tile.type.typeId)
            {
                possibleMovments.Add(Tile.N);
            }
            if (neighbours[Tile.E].type.myState == State.Gas && neighbours[Tile.E].type.typeId != tile.type.typeId)
            {
                possibleMovments.Add(Tile.E);
            }
            if (neighbours[Tile.W].type.myState == State.Gas && neighbours[Tile.W].type.typeId != tile.type.typeId)
            {
                possibleMovments.Add(Tile.W);
            }
            if(possibleMovments.Count > 0)
            {
                int r = possibleMovments[Random.Range(0, possibleMovments.Count)];
                neighbours[r].SetType(tile.type);
                tile.SetType(listOfTypes.types[0]);
            }
            


        }
            else if(myState == State.Liquid)
        {
            if (neighbours[Tile.S].type.myState == State.Gas)
            {
                //Fall down
                neighbours[Tile.S].SetType(tile.type);
                neighbours[Tile.S].direction = 0;
                tile.SetType(listOfTypes.types[0]);
                tile.direction = 0;

            }
            //if water is under
            //if solid is under Spread to the sides if it is air
            else if (neighbours[Tile.S].type.myState == State.Solid || neighbours[Tile.S].type.myState == State.Liquid)
            {

                if (neighbours[Tile.W].type.myState != State.Gas && neighbours[Tile.E].type.myState != State.Gas)
                {
                    return;
                }

                tile.direction = GetDirection(tile.direction);


                if (neighbours[tile.direction].type.myState == State.Gas)
                {
                    neighbours[tile.direction].SetType(tile.type);
                    neighbours[tile.direction].direction = tile.direction;
                    tile.SetType(listOfTypes.types[0]);
                    tile.direction = 0;
                }
                else if (neighbours[GetReverse(tile.direction)].type.myState == State.Gas)
                {

                    neighbours[GetReverse(tile.direction)].SetType(tile.type);
                    neighbours[GetReverse(tile.direction)].direction = GetReverse(tile.direction);
                    tile.SetType(listOfTypes.types[0]);
                    tile.direction = 0;
                }
                if (neighbours[Tile.E].type.myState == State.Gas)
                {
                    neighbours[Tile.E].SetType(tile.type);
                }
            }

        }
        else if(myState == State.Solid)
        {
            //Debug.Log("Uppdating Earth");
            //if gas is under
            if (neighbours[Tile.S].type.myState == State.Gas || neighbours[Tile.S].type.myState == State.Animal)
            {
                //Fall down
                neighbours[Tile.S].SetType(tile.type);
                tile.SetType(listOfTypes.types[0]);

            }
            //if water is under
            else if (neighbours[Tile.S].type.myState == State.Liquid)
            {
                neighbours[Tile.S].SetType(tile.type);
                tile.SetType(listOfTypes.types[0]);

            }
            //if solid is under Spread to the sides if it is air
            else if (neighbours[Tile.S].type.myState == State.Solid)
            {
                if (neighbours[Tile.N].type.myState == State.Solid)
                {
                    if (neighbours[Tile.W].type.myState == State.Gas || neighbours[Tile.E].type.myState == State.Gas)
                    {
                        if (CalculatePressure(tile) > rigidity)
                        {
                            if (neighbours[Tile.W].type.myState == State.Gas)
                            {
                                neighbours[Tile.W].SetType(tile.type);
                                tile.SetType(listOfTypes.types[0]);
                            }
                            else
                            {
                                neighbours[Tile.E].SetType(tile.type);
                                tile.SetType(listOfTypes.types[0]);
                            }
                        }
                    }
                }
            }

        }
    }

    public virtual void CheckNeigbourConnections(Tile tile)
    {

    }

    public virtual void FirstUppdate(Tile t)
    {
        t.SetSprite(sprite, c);
    }

    public int GetDirection(int prev)
    {
        int r = prev;
        if(prev == 0)
        {
            r = Random.Range(1, 2);
            if( r == 2)
            {
                r = 3;
            }
        }
        return r;
    }

    public int GetReverse(int prev)
    {
        if(prev == 1) { return 3;}
        else { return 1; }
    }

    public int CalculatePressure(Tile t)
    {
        int pressure = 0;
        while(t.neighbours[Tile.N] != null && t.neighbours[Tile.N].type.typeId != "B")
        {
            pressure += t.neighbours[Tile.N].type.weight;
            t = t.neighbours[Tile.N];
            if(t.type.myState == State.Gas)
            {
                return pressure;
            }
        }

        return pressure;
    }

    
}
