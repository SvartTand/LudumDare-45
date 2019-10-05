using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeEarth : Type {

    public override void UpdateTile(Tile tile, Tile[] neighbours)
    {
        Debug.Log("Uppdating Earth");
        //if gas is under
        if (neighbours[Tile.S].type.myState == State.Gas)
        {
            //Fall down
            neighbours[Tile.S].SetType(tile.type);
            tile.SetType(listOfTypes.types[0]);

        }
        //if water is under
        else if (neighbours[Tile.S].type.myState == State.Liquid)
        {
            tile.SetType(listOfTypes.types[0]);

        }
        //if solid is under Spread to the sides if it is air
        else if (neighbours[Tile.S].type.myState == State.Solid)
        {
            if (neighbours[Tile.W].type.myState == State.Gas)
            {
                neighbours[Tile.W].SetType(tile.type);
            }
            if (neighbours[Tile.E].type.myState == State.Gas)
            {
                neighbours[Tile.E].SetType(tile.type);
            }
        }

    }
}
