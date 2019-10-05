using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public Tile[,] world;
    public int height;
    public int width;
    public float tileDimensions;

    public Tile tile;


	// Use this for initialization
	void Start () {
        world = new Tile[width, height];
        CreateWorld();
	}

    private void CreateWorld()
    {
        for(int i = 0; i < world.GetLength(0); i++)
        {
            for (int j = 0; j < world.GetLength(1); j++)
            {
                //Debug.Log(i + ", " + j + ", dim: " + world.Length);
                Transform temp = transform;
                world[i, j] = Instantiate(tile, new Vector3(transform.position.x + i * tileDimensions, transform.position.y + j * tileDimensions , 0), transform.rotation);
                world[i, j].GetComponent<Tile>().Init(i, j);

                world[i, j].transform.parent = transform;
                SetNeighbours(i, j);
            }
        }
    }

    private void SetNeighbours(int x, int y)
    {
        if(x >= 1)
        {
            world[x, y].AddNeighbour(world[x - 1, y], 3);
            world[x - 1, y].AddNeighbour(world[x, y], 1);
        }
        if(y >= 1)
        {
            world[x, y].AddNeighbour(world[x, y - 1], 2);
            world[x, y - 1].AddNeighbour(world[x, y], 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
