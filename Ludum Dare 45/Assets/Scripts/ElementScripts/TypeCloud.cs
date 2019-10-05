using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeCloud : Type {

    public override void UpdateTile(Tile tile, Tile[] neighbours)
    {
        List<int> possibleMovments = new List<int>();
        if (neighbours[Tile.E].type.myState == State.Gas && neighbours[Tile.E].type.typeId != tile.type.typeId)
        {
            possibleMovments.Add(Tile.E);
        }
        if (neighbours[Tile.W].type.myState == State.Gas && neighbours[Tile.W].type.typeId != tile.type.typeId)
        {
            possibleMovments.Add(Tile.W);
        }
        if (possibleMovments.Count > 0)
        {
            int r = possibleMovments[Random.Range(0, possibleMovments.Count)];
            neighbours[r].SetType(tile.type);
            tile.SetType(listOfTypes.types[0]);
        }
    }

    public override void CheckNeigbourConnections(Tile tile)
    {
        //if all neighbours are clouds beckome lightning
        //if 3 neighbours are clouds become water

        int counter = 0;
        for (int i = 0; i < tile.neighbours.Length; i++)
        {
            if(tile.neighbours[i].type == this)
            {
                counter++;
            }
        }

        if(counter == 4)
        {
            tile.SetType(listOfTypes.types[ListOfTypes.LIGHTNING]);
        }

        if(counter == 3)
        {
            tile.SetType(listOfTypes.types[ListOfTypes.WATER]);
        }
    }
}
