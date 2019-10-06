using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeAlgee : Type {

    public int lifeSpan;
    public List<Color> colors = new List<Color>();

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

        int ra = Random.Range(0, colors.Count);
        tile.SetSprite(sprite, colors[ra]);
    }

    public override void FirstUppdate(Tile t)
    {
        SetButtonInteractable();
        int ra = Random.Range(0, colors.Count);
        t.SetSprite(sprite, colors[ra]);
    }
}
