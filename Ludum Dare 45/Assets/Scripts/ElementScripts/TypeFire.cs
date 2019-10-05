using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeFire : Type {

    public List<Sprite> anima;

    public float decayTime;

    public override void CheckNeigbourConnections(Tile tile)
    {

        if(tile.neighbours[Tile.S].type.myState != State.Solid)
        {
            tile.SetType(listOfTypes.types[ListOfTypes.STEAM]);
        }

        for(int i = 0; i < tile.neighbours.Length; i++)
        {
            if (tile.neighbours[i].type.burnable)
            {
                tile.neighbours[i].SetType(this);
            }
        }

        int ra = Random.Range(0, anima.Count);
        tile.SetSprite(anima[ra], c);

        tile.typeCounter += updInterval;
        if (tile.typeCounter >= decayTime)
        {
            tile.SetType(listOfTypes.types[ListOfTypes.ASH]);
        }
    }
}
