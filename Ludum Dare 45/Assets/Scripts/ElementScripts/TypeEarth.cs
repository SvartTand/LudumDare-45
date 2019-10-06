using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeEarth : Type {

    public List<Color> depthColor = new List<Color>();
    public int pressureToCreateStone;

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
            neighbours[Tile.S].SetType(tile.type);
            tile.SetType(listOfTypes.types[0]);

        }
        //if solid is under Spread to the sides if it is air
        else if (neighbours[Tile.S].type.myState == State.Solid)
        {
            if(neighbours[Tile.N].type.myState == State.Solid)
            {
                if(neighbours[Tile.W].type.myState == State.Gas || neighbours[Tile.E].type.myState == State.Gas)
                {
                    if(CalculatePressure(tile) > rigidity)
                    {
                        if(neighbours[Tile.W].type.myState == State.Gas)
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

    public override void FirstUppdate(Tile t)
    {

        c = depthColor[0];
        t.SetSprite(sprite, c);
    }

    public override void CheckNeigbourConnections(Tile tile)
    {

        int press = CalculatePressure(tile);
        if(press == tile.prevPressure)
        {
            return;
        }
        if (press >= pressureToCreateStone)
        {
            tile.SetType(listOfTypes.types[ListOfTypes.STONE]);
            return;
        }

        if(press <= weight * 1)
        {
            c = depthColor[0];
            tile.SetSprite(sprite, c);
            return;
        }
        if (press <= weight * 3)
        {
            c = depthColor[1];
            tile.SetSprite(sprite, c);
            return;
        }
        else
        {
            c = depthColor[2];
            tile.SetSprite(sprite, c);
            return;
        }


    }

    public override void SetButtonInteractable()
    {

    }
}
