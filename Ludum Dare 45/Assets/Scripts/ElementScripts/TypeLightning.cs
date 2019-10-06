using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeLightning : Type {

    public int chanseOfGoingSideway;

    public AudioSource audio;

    public override void UpdateTile(Tile tile, Tile[] neighbours)
    {
        
        int r = Random.Range(0, chanseOfGoingSideway);
        if(r == 1 || r == 3)
        {
            if (neighbours[r].type.myState == State.Gas)
            {
                neighbours[r].SetType(listOfTypes.types[ListOfTypes.LIGHTNING]);
                neighbours[r].type.UpdateTile(neighbours[r], neighbours[r].neighbours);
            }
            else
            {
                if(neighbours[r].type.myState != State.Plasma)
                {
                    if (neighbours[r].type == listOfTypes.types[ListOfTypes.WATER])
                    {
                        neighbours[r].SetType(listOfTypes.types[ListOfTypes.ALGEE]);
                    }
                    else if (neighbours[r].type.burnable)
                    {
                        neighbours[r].SetType(listOfTypes.types[ListOfTypes.FIRE]);
                    }
                    audio.Play();
                    GroundHit(tile);
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraHandler>().Shake(0.7f, 0.5f);
                    
                }
                
            }
        }
        else
        {
            if (neighbours[Tile.S].type.myState == State.Gas)
            {
                neighbours[Tile.S].SetType(listOfTypes.types[ListOfTypes.LIGHTNING]);
            }
            else
            {
                if (neighbours[Tile.S].type.myState != State.Plasma)
                {

                    if (neighbours[Tile.S].type == listOfTypes.types[ListOfTypes.WATER])
                    {
                        neighbours[Tile.S].SetType(listOfTypes.types[ListOfTypes.ALGEE]);
                    }
                    else if (neighbours[Tile.S].type == listOfTypes.types[ListOfTypes.CACTUS]) {
                        neighbours[Tile.S].SetType(listOfTypes.types[ListOfTypes.ANIMAL]);
                    }
                    else if (neighbours[Tile.S].type == listOfTypes.types[ListOfTypes.ANIMAL])
                    {
                        neighbours[Tile.S].SetType(listOfTypes.types[ListOfTypes.MAN]);
                    }
                    else if (neighbours[Tile.S].type.burnable)
                    {
                        neighbours[Tile.S].SetType(listOfTypes.types[ListOfTypes.FIRE]);
                    }
                    audio.Play();
                    GroundHit(tile);
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraHandler>().Shake(0.01f, 0.2f);
                }
            }
        }
        
    }

    public override void FirstUppdate(Tile t)
    {
        SetButtonInteractable();
        t.SetSprite(sprite, c);
    }

    private void GroundHit(Tile t)
    {
        t.SetType(listOfTypes.types[0]);
        for (int i = 0; i < t.neighbours.Length; i++)
        {
            if(t.neighbours[i].type.typeId == "Li")
            {
                
                GroundHit(t.neighbours[i]);
                break;
            }
        }
    }
}
