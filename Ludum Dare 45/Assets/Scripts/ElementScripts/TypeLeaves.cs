using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeLeaves : Type {

    public List<Sprite> anim;

    public override void CheckNeigbourConnections(Tile tile)
    {
        int ra = Random.Range(0, anim.Count);
        tile.SetSprite(anim[ra], c);

        for (int i = 0; i < tile.neighbours.Length; i++)
        {
            if(tile.neighbours[i].type.typeId == "T")
            {
                return;
            }
        }

        tile.SetType(listOfTypes.types[ListOfTypes.STEAM]);
    }

    public override void UpdateTile(Tile tile, Tile[] neighbours)
    {
        
    }

    
}
