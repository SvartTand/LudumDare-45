using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeLightning : Type {

    public int chanseOfGoingSideway;

    public override void UpdateTile(Tile tile, Tile[] neighbours)
    {
        
        int r = Random.Range(0, chanseOfGoingSideway);
        if(r == 1 || r == 3)
        {
            if (neighbours[r].type.myState == State.Gas)
            {
                neighbours[r].SetType(listOfTypes.types[ListOfTypes.LIGHTNING]);
                neighbours[r].type.UpdateTile(neighbours[r], neighbours[r].neighbours);
            }
            else
            {
                if(neighbours[r].type.myState != State.Plasma)
                {
                    GroundHit(tile);
                }
                
            }
        }
        else
        {
            if (neighbours[Tile.S].type.myState == State.Gas)
            {
                neighbours[Tile.S].SetType(listOfTypes.types[ListOfTypes.LIGHTNING]);
            }
            else
            {
                if (neighbours[Tile.S].type.myState != State.Plasma)
                {
                    GroundHit(tile);
                }
            }
        }
        
    }

    public override void FirstUppdate(Tile t)
    {
        t.SetSprite(sprite, c);
    }

    private void GroundHit(Tile t)
    {
        t.SetType(listOfTypes.types[0]);
        for (int i = 0; i < t.neighbours.Length; i++)
        {
            if(t.neighbours[i].type.typeId == "Li")
            {
                
                GroundHit(t.neighbours[i]);
                break;
            }
        }
    }
}
