using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type : MonoBehaviour {

    public string typeId;
    public Sprite sprite;
    public Color c;

    public ListOfTypes listOfTypes;

    public float updInterval;

    public enum State { Solid, Liquid, Gas};
    public State myState;


    public virtual void UpdateTile(Tile tile, Tile[] neighbours)
    {
        Debug.Log("Update Base Type");
    }
    public virtual void FirstUppdate(Tile t)
    {
        t.SetSprite(sprite, c);
    }
}
