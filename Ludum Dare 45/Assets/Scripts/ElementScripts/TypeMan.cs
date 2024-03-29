﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeMan : Type {

    public List<Sprite> anima = new List<Sprite>();


    public override void CheckNeigbourConnections(Tile tile)
    {
        int ra = Random.Range(0, anima.Count);
        tile.SetSprite(anima[ra], c);

        if (tile.neighbours[Tile.S].type.typeId == "Br"){

            if (listOfTypes.types[ListOfTypes.GLASS].IsUnlocked())
            {
                BuildHouse(tile);
                listOfTypes.HouseBuilt();

            }
            

        }

        if (tile.neighbours[Tile.S].type.typeId == "Me")
        {

            if (listOfTypes.types[ListOfTypes.GLASS].IsUnlocked())
            {
                BuildSkyScraper(tile);
                listOfTypes.HouseBuilt();


            }


        }
    }

    public override void FirstUppdate(Tile t)
    {
        
        SetButtonInteractable();
        int ra = Random.Range(0, anima.Count);
        t.SetSprite(anima[ra], c);
    }

    private void BuildHouse(Tile tile)
    {
        tile.SetType(listOfTypes.types[ListOfTypes.GLASS]);

        for(int i = 0; i < tile.neighbours.Length; i++)
        {
            tile.neighbours[i].SetType(listOfTypes.types[ListOfTypes.BRICKS]);
        }
        tile.neighbours[Tile.S].neighbours[Tile.E].SetType(listOfTypes.types[ListOfTypes.BRICKS]);
        tile.neighbours[Tile.S].neighbours[Tile.W].SetType(listOfTypes.types[ListOfTypes.BRICKS]);

    }

    private void BuildSkyScraper(Tile tile)
    {
        int height = Random.Range(2, 10);
        tile.neighbours[Tile.S].neighbours[Tile.E].SetType(listOfTypes.types[ListOfTypes.METAL]);
        tile.neighbours[Tile.S].neighbours[Tile.W].SetType(listOfTypes.types[ListOfTypes.METAL]);

        tile.neighbours[Tile.S].SetType(listOfTypes.types[ListOfTypes.METAL]);

        while (height > 0)
        {
            if(height%2 == 1)
            {
                tile.neighbours[Tile.W].SetType(listOfTypes.types[ListOfTypes.METAL]);
                tile.neighbours[Tile.E].SetType(listOfTypes.types[ListOfTypes.METAL]);
                tile.SetType(listOfTypes.types[ListOfTypes.GLASS]);
            }
            else
            {
                tile.neighbours[Tile.W].SetType(listOfTypes.types[ListOfTypes.METAL]);
                tile.neighbours[Tile.E].SetType(listOfTypes.types[ListOfTypes.METAL]);
                tile.SetType(listOfTypes.types[ListOfTypes.METAL]);
            }
            tile = tile.neighbours[Tile.N];



            height--;
        }



    }
}
