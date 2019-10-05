using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {


    private Tile[] neighbours = new Tile[4];
    private Vector2 pos;

    public static int N = 0, E = 1, S = 2, W = 3;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init(int x, int y)
    {
        pos = new Vector2(x, y);
    }

    public void AddNeighbour(Tile neighbour, int p)
    {
        Debug.Log(p + ", " + neighbours.Length);
        neighbours[p] = neighbour;
    }

    public void IsClickedOn()
    {
        Debug.Log(pos);
    }
}
