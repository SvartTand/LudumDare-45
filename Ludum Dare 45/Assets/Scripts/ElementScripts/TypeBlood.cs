using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeBlood : Type {


    public List<Color> colors = new List<Color>();

    public override void CheckNeigbourConnections(Tile tile)
    {
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
