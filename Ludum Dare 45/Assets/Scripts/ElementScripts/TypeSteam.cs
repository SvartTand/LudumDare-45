using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeSteam : Type {

    public int chanceToCreateCloud;
    public int chanceOfDecay;

    public override void CheckNeigbourConnections(Tile tile)
    {
        Debug.Log("Uppdating Steam");
        int r = Random.Range(0, chanceOfDecay);
        Debug.Log(r);
        if (r == 1)
        {
            tile.SetType(listOfTypes.types[0]);
        }

        int x = 0;
        for (int i = 0; i < tile.neighbours.Length; i++)
        {
            if (tile.neighbours[i].type.typeId == typeId)
            {
                x++;
                
            }else if(tile.neighbours[i].type.typeId == "C")
            {
                tile.SetType(listOfTypes.types[ListOfTypes.CLOUD]);
                break;
            }
        }

        if(x == 4)
        {
  
            tile.SetType(listOfTypes.types[ListOfTypes.CLOUD]);
        }

        
    }

    public override void UpdateTile(Tile tile, Tile[] neighbours)
    {
        List<int> possibleMovments = new List<int>();
        if (neighbours[Tile.N].type.myState == State.Gas && neighbours[Tile.N].type.typeId != tile.type.typeId && neighbours[Tile.N].type.typeId != "C")
        {
            possibleMovments.Add(Tile.N);
        }
        if (neighbours[Tile.E].type.myState == State.Gas && neighbours[Tile.E].type.typeId != tile.type.typeId && neighbours[Tile.E].type.typeId != "C")
        {
            possibleMovments.Add(Tile.E);
        }
        if (neighbours[Tile.W].type.myState == State.Gas && neighbours[Tile.W].type.typeId != tile.type.typeId && neighbours[Tile.W].type.typeId != "C")
        {
            possibleMovments.Add(Tile.W);
        }
        if (possibleMovments.Count > 0)
        {
            int r = possibleMovments[Random.Range(0, possibleMovments.Count)];
            neighbours[r].SetType(tile.type);
            tile.SetType(listOfTypes.types[0]);
        }


    }


}
