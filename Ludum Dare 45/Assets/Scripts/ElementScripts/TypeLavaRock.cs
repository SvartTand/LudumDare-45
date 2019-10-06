using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeLavaRock : Type {

    public override void CheckNeigbourConnections(Tile tile)
    {
        for (int i = 0; i < tile.neighbours.Length; i++){
            if(tile.neighbours[i].type.typeId == "F")
            {
                tile.SetType(listOfTypes.types[ListOfTypes.METAL]);
            }
        }
    }
}
