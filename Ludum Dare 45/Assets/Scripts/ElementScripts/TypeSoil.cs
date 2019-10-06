using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeSoil : Type {

    public int pressureToCreateClay;
    public List<Color> colors;

    public override void CheckNeigbourConnections(Tile tile)
    {
        int press = CalculatePressure(tile);
        if (press == tile.prevPressure)
        {
            return;
        }
        if (press >= pressureToCreateClay)
        {
            tile.SetType(listOfTypes.types[ListOfTypes.CLAY]);
            return;
        }

        if (press <= weight * 1)
        {
            c = colors[0];
            tile.SetSprite(sprite, c);
            return;
        }
        if (press <= weight * 3)
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
