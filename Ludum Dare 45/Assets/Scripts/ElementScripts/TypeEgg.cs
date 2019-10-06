using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeEgg : Type {

    public float cooldown;

    public override void CheckNeigbourConnections(Tile tile)
    {
        tile.typeCounter += updInterval;
        if (tile.typeCounter >= cooldown)
        {
            tile.SetType(listOfTypes.types[ListOfTypes.BIRD]);
        }
    }
}
