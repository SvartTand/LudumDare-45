using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {


    private Tile[] neighbours = new Tile[4];
    private Vector2 pos;

    public static int N = 0, E = 1, S = 2, W = 3;

    public Type type;
    private float timer = 0;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        //Debug.Log(type.updInterval);
        if(timer >= type.updInterval)
        {
            type.UpdateTile(this, neighbours);
            timer = 0;
        }
	}

    public void Init(int x, int y, Type t)
    {
        pos = new Vector2(x, y);
        SetType(t);
    }

    public void AddNeighbour(Tile neighbour, int p)
    {
        Debug.Log(p + ", " + neighbours.Length);
        neighbours[p] = neighbour;
    }

    public void IsClickedOn(Type newType)
    {
        SetType(newType);
        Debug.Log(pos);
    }

    public void SetSprite(Sprite sp, Color c)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sp;
        gameObject.GetComponent<SpriteRenderer>().color = c;
    }

    public void SetType(Type t)
    {
        type = t;
        type.FirstUppdate(this);
        timer = 0;
    }
}
