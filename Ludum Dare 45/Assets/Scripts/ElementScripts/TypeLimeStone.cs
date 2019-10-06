using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeLimeStone : Type {

    public List<Color> colors;

    public override void CheckNeigbourConnections(Tile tile)
    {
        for(int i = 0; i < tile.neighbours.Length; i++)
        {
            if(tile.neighbours[i].type.typeId == "Ani")
            {
                tile.SetType(listOfTypes.types[ListOfTypes.EGG]);
            }
        }

        int press = CalculatePressure(tile);
        if (press == tile.prevPressure)
        {
            return;
        }

        if (press <= weight * 1)
        {
            c = colors[0];
            tile.SetSprite(sprite, c);
            return;
        }
        if (press <= weight * 2)
        {
            c = colors[1];
            tile.SetSprite(sprite, c);
            return;
        }
        else
        {
            c = colors[2];
            tile.SetSprite(sprite, c);
            return;
        }
    }
}
