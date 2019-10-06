using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeGrass : Type {

    public int chanceOfSpreading;
    public int chanceOfTree;
    public List<Sprite> anim = new List<Sprite>();

    public override void CheckNeigbourConnections(Tile tile)
    {
        if(tile.neighbours[Tile.S].type.typeId == "Sa")
        {
            tile.SetType(listOfTypes.types[ListOfTypes.CACTUS]);
            return;
        }

        if(tile.neighbours[Tile.N].type.myState == State.Solid || tile.neighbours[Tile.N].type.myState == State.Liquid)
        {
            tile.SetType(listOfTypes.types[ListOfTypes.SOIL]);
            return;
        }

        int r = Random.Range(0, chanceOfSpreading);

        if(r == Tile.W || r == Tile.E)
        {
            if((tile.neighbours[r].type.typeId == "So" || tile.neighbours[r].type.typeId == "As") && tile.neighbours[r].neighbours[Tile.N].type.myState == State.Gas)
            {
                tile.neighbours[r].SetType(this);
            }
        }

        int r1 = Random.Range(0, chanceOfTree);
        if(r1 == 1)
        {
            tile.SetType(listOfTypes.types[ListOfTypes.TREE]);
            return;
        }

        int ra = Random.Range(0, anim.Count);
        tile.SetSprite(anim[ra], c);

    }

    public override void FirstUppdate(Tile t)
    {
        SetButtonInteractable();
        int ra = Random.Range(0, anim.Count);
        t.SetSprite(anim[ra], c);
    }
}
