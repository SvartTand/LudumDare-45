using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeWater : Type {



    public int chanceToCreateSand;
    public int chanceToCreateSteamWithLava;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void UpdateTile(Tile tile, Tile[] neighbours)
    {
        Debug.Log("Uppdating Water");
        //if gas is under
        if(neighbours[Tile.S].type.myState == State.Gas)
        {
            //Fall down
            neighbours[Tile.S].SetType(tile.type);
            neighbours[Tile.S].direction = 0;
            tile.SetType(listOfTypes.types[0]);
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
                    tile.neighbours[i].SetType(listOfTypes.GetType("Sand"));
                }
            }

            if (tile.neighbours[i].type.typeId == "L")
            {
                int r = Random.Range(0, chanceToCreateSteamWithLava);
                if (r == 1)
                {
                    tile.SetType(listOfTypes.GetType("Steam"));
                }
            }
        }
    }

    public override void FirstUppdate(Tile t)
    {
        t.SetSprite(sprite, c);
    }

}
