using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeAnimal : Type {

    public List<Sprite> anima = new List<Sprite>();

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
