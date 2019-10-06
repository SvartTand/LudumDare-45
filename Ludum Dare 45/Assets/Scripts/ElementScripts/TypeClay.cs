using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeClay : Type {

    public List<Color> colors;

    public override void CheckNeigbourConnections(Tile tile)
    {
        //if human beside clay -> bricks
        for (int i = 0; i < tile.neighbours.Length; i++)
        {
            if(tile.neighbours[i].type.typeId == "M")
            {
                tile.SetType(listOfTypes.types[ListOfTypes.BRICKS]);
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
