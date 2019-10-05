using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeStone : Type {

    public int pressureToCreateLava;

    public override void CheckNeigbourConnections(Tile tile)
    {
        if(CalculatePressure(tile) > pressureToCreateLava)
        {
            tile.SetType(listOfTypes.types[ListOfTypes.LAVA]);
        }
    }

    public override void UpdateTile(Tile tile, Tile[] neighbours)
    {
        Debug.Log("Uppdating Stone");
        //if gas is under
        if (neighbours[Tile.S].type.myState == State.Gas )
        {
            //Fall down
            neighbours[Tile.S].SetType(tile.type);
            tile.SetType(listOfTypes.types[0]);

        }
        //if water is under
        else if (neighbours[Tile.S].type.myState == State.Liquid && neighbours[Tile.S].type.typeId != "L")
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
