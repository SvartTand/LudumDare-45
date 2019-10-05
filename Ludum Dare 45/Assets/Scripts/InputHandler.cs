using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    public Type type;

    public int brushSize;

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform.tag == "Tile")
                {
                    hit.transform.gameObject.GetComponent<Tile>().IsClickedOn(type, brushSize);
                }
                //Debug.Log(hit.transform.name);
            }
        }
    }

    public void ElementSelected(Type t)
    {
        type = t;
    }

    public void PausePressed()
    {
        Time.timeScale = 0;
    }
    public void PlayPressed()
    {
        Time.timeScale = 1.0f;
    }
    public void SpeedUpPressed()
    {
        Time.timeScale = 1.5f;
    }
}
