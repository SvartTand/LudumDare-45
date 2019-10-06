using System.Collections;
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

    public float typeCounter;

    public GameObject shadow;

    private int shadowTimer = 0;


    public void Highlight(int brush)
    {
        shadow.active = true;
        shadowTimer = 1;
        if (brush > 1)
        {
            for (int i = 0; i < neighbours.Length; i++)
            {
                if (neighbours[i].type.typeId != "B")
                {
                    neighbours[i].SetHighligth(brush - 1);
                }

            }
        }
    }

    public void SetHighligth(int brush)
    {
        shadow.active = true;
        shadowTimer = 1;
        if (brush > 1)
        {
            for (int i = 0; i < neighbours.Length; i++)
            {
                if (neighbours[i].type.typeId != "B")
                {
                    neighbours[i].SetHighligth( brush - 1);
                }

            }
        }
    }


	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        //Debug.Log(type.updInterval);
        if(timer >= type.updInterval)
        {
            type.CheckNeigbourConnections(this);
            type.UpdateTile(this, neighbours);
            
            timer = 0;
        }
        if (shadow.active)
        {
            if(shadowTimer == 1)
            {
                shadowTimer--;
            }
            else
            {
                shadow.active = false;
            }

        }
	}

    public Vector2 GetPos()
    {
        return pos;
    }

    public void Init(int x, int y, Type t)
    {
        pos = new Vector2(x, y);
        SetType(t);
    }

    public void AddNeighbour(Tile neighbour, int p)
    {
        //Debug.Log(p + ", " + neighbours.Length);
        neighbours[p] = neighbour;
    }

    public void IsClickedOn(Type newType, int brushSize)
    {
        if(type.typeId == "A")
        {
            newType.listOfTypes.AddedMatter(newType.weight);
            if(newType.typeId == "M")
            {
                newType.listOfTypes.HumanBorn();
            }
            SetType(newType);
        }
        
        if(brushSize > 1)
        {
            for(int i = 0; i < neighbours.Length; i++)
            {
                if(neighbours[i].type.typeId != "B")
                {
                    neighbours[i].SetNeighbours(newType, brushSize - 1);
                }
                
            }
        }
        //Debug.Log(pos);
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
        typeCounter = 0;
    }

    public void SetNeighbours(Type newType, int depth)
    {
        if (type.typeId == "A")
        {
            SetType(newType);
            if (newType.typeId == "M")
            {
                newType.listOfTypes.HumanBorn();
            }
            newType.listOfTypes.AddedMatter(newType.weight);
        }
        if (depth > 1)
        {
            for (int i = 0; i < neighbours.Length; i++)
            {
                if (neighbours[i].type.typeId != "B")
                {
                    neighbours[i].SetNeighbours(newType, depth - 1);
                }
                
            }
        }
    }
}
