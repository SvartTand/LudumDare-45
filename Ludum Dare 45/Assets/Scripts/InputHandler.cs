using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour {

    public Type type;

    public int brushSize;

    public Button brush1;
    public Button brush2;
    public Button brush3;

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

    public void BrushButtonPressed1()
    {
        brushSize = 1;
        brush1.interactable = false;
        brush2.interactable = true;
        brush3.interactable = true;
    }
    public void BrushButtonPressed2()
    {
        brushSize = 2;
        brush1.interactable = true;
        brush2.interactable = false;
        brush3.interactable = true;
    }
    public void BrushButtonPressed3()
    {
        brushSize = 3;
        brush1.interactable = true;
        brush2.interactable = true;
        brush3.interactable = false;
    }
}
