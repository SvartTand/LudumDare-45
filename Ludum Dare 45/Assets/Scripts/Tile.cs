﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {


    public Tile[] neighbours = new Tile[4];
    private Vector2 pos;

    public static int N = 0, E = 1, S = 2, W = 3;

    public Type type;
    private float timer = 0;

    public int direction;
    public int prevPressure;

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
            type.CheckNeigbourConnections(this);
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

    public void IsClickedOn(Type newType, int brushSize)
    {
        SetType(newType);
        if(brushSize > 1)
        {
            for(int i = 0; i < neighbours.Length; i++)
            {
                neighbours[i].SetNeighbours(newType, brushSize - 1);
            }
        }
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

    public void SetNeighbours(Type newType, int depth)
    {
        SetType(newType);
        if (depth > 1)
        {
            for (int i = 0; i < neighbours.Length; i++)
            {
                neighbours[i].SetNeighbours(newType, depth - 1);
            }
        }
    }
}
