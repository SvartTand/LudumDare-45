using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeAlgee : Type {

    public int lifeSpan;

    public override void CheckNeigbourConnections(Tile tile)
    {
        if(tile.neighbours[Tile.E].type.typeId == "W")
        {
            if(tile.neighbours[Tile.E].neighbours[Tile.E].type.typeId == "Al")
            {
                tile.neighbours[Tile.E].SetType(listOfTypes.types[ListOfTypes.ALGEE]);
            }
        }

        if (tile.neighbours[Tile.W].type.typeId == "W")
        {
            if (tile.neighbours[Tile.W].neighbours[Tile.W].type.typeId == "Al")
            {
                tile.neighbours[Tile.W].SetType(listOfTypes.types[ListOfTypes.ALGEE]);
            }
        }

        if(tile.neighbours[Tile.S].type.typeId == "So")
        {
            tile.SetType(listOfTypes.types[ListOfTypes.GRASS]);
        }

        tile.typeCounter += updInterval;
        if(tile.typeCounter >= lifeSpan)
        {
            tile.SetType(listOfTypes.types[ListOfTypes.SOIL]);
        }
    }
}
