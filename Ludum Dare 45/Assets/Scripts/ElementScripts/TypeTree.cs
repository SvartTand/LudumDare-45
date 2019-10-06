using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeTree : Type {

    public int chanceOfGrowing;

    public override void FirstUppdate(Tile t)
    {
        base.FirstUppdate(t);

        int ra = Random.Range(0, chanceOfGrowing);

        if(ra == 1)
        {
            t.neighbours[Tile.N].SetType(listOfTypes.types[ListOfTypes.TREE]);
        }
        else
        {
            //grow leaves
            t.neighbours[Tile.N].SetType(listOfTypes.types[ListOfTypes.LEAVES]);
            t.neighbours[Tile.W].SetType(listOfTypes.types[ListOfTypes.LEAVES]);
            t.neighbours[Tile.E].SetType(listOfTypes.types[ListOfTypes.LEAVES]);

        }
    }
}
