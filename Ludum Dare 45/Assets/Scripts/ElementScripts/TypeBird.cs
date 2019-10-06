using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeBird : Type {

    public List<Sprite> anima = new List<Sprite>();

    public override void UpdateTile(Tile tile, Tile[] neighbours)
    {
        if (myState == State.Animal)
        {
            if (neighbours[Tile.N].type.myState != State.Gas && neighbours[Tile.N].type.myState != State.Animal && neighbours[Tile.N].type.myState != State.Liquid)
            {
                //Kill animal
                tile.SetType(listOfTypes.types[ListOfTypes.BLOOD]);
                listOfTypes.AnimalKilled();

                if (tile.type.typeId == "M")
                {
                    listOfTypes.HumanKilled();
                }
                return;
            }

            List<Tile> possibleMoves = new List<Tile>();

            for (int i = 0; i < neighbours.Length; i++)
            {
                if(neighbours[i].type.myState == State.Gas)
                {
                    possibleMoves.Add(neighbours[i]);
                }
            }
            if (possibleMoves.Count >= 1)
            {
                int r = Random.Range(0, possibleMoves.Count);
                possibleMoves[r].SetType(tile.type);
                tile.SetType(listOfTypes.types[0]);
            }


        }
    }

    public override void CheckNeigbourConnections(Tile tile)
    {
        int ra = Random.Range(0, anima.Count);
        tile.SetSprite(anima[ra], c);
    }

    public override void FirstUppdate(Tile t)
    {
        SetButtonInteractable();
        int ra = Random.Range(0, anima.Count);
        t.SetSprite(anima[ra], c);
    }


}
