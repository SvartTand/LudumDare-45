using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeLava : Type {

    public List<Color> colors = new List<Color>();

    public override void CheckNeigbourConnections(Tile tile)
    {
        for(int i = 0; i < tile.neighbours.Length; i++)
        {
            if(tile.neighbours[i].type.typeId == "So")
            {
                tile.neighbours[i].SetType(listOfTypes.types[ListOfTypes.CLAY]);
            }
        }

        int ra = Random.Range(0, colors.Count);
        tile.SetSprite(sprite, colors[ra]);


    }

    public override void FirstUppdate(Tile t)
    {
        int ra = Random.Range(0, colors.Count);
        t.SetSprite(sprite, colors[ra]);
    }
}
