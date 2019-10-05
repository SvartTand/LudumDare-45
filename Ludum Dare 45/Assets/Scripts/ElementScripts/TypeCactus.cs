using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeCactus : Type {

    public override void CheckNeigbourConnections(Tile tile)
    {

        if (tile.neighbours[Tile.S].type.typeId != "Sa" && tile.neighbours[Tile.S].type.typeId != typeId)
        {
            
            tile.SetType(listOfTypes.types[ListOfTypes.SOIL]);
        }

        if (tile.neighbours[Tile.S].type.typeId == "Sa" && tile.neighbours[Tile.N].type.myState == State.Gas)
        {
            tile.neighbours[Tile.N].SetType(listOfTypes.types[ListOfTypes.CACTUS]);
        }
    }
}
