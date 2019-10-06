using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeWater : Type {



    public int chanceToCreateSand;
    public int chanceToCreateSteamWithLava;
    public List<Color> colors = new List<Color>();

    public override void UpdateTile(Tile tile, Tile[] neighbours)
    {
        //Debug.Log("Uppdating Water");
        //if gas is under
        if(neighbours[Tile.S].type.myState == State.Gas)
        {
            //Fall down
            Type prevType = neighbours[Tile.S].type;
            neighbours[Tile.S].SetType(tile.type);
            neighbours[Tile.S].direction = 0;
            tile.SetType(prevType);
            tile.direction = 0;
            
        }
        //if water is under
        //if solid is under Spread to the sides if it is air
        else if(neighbours[Tile.S].type.myState == State.Solid || neighbours[Tile.S].type.myState == State.Liquid)
        {

            if(neighbours[Tile.W].type.myState != State.Gas && neighbours[Tile.E].type.myState != State.Gas)
            {
                return;
            }
            
            tile.direction = GetDirection(tile.direction);

            
            if(neighbours[tile.direction].type.myState == State.Gas)
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

    public override void CheckNeigbourConnections(Tile tile)
    {
        for(int i = 0; i < tile.neighbours.Length; i++)
        {
            if(tile.neighbours[i].type.typeId == "S")
            {
                int r = Random.Range(0, chanceToCreateSand);
                if(r == 1)
                {
                    tile.neighbours[i].SetType(listOfTypes.types[ListOfTypes.SAND]);
                }
            }

            
        }
        int ra = Random.Range(0, colors.Count);
        tile.SetSprite(sprite, colors[ra]);
    }

    public override void FirstUppdate(Tile t)
    {
        int ra = Random.Range(0, colors.Count);
        t.SetSprite(sprite, colors[ra]);
    }

}
