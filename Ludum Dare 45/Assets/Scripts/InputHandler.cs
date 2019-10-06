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

    public Button Pause;
    public Button Play;
    public Button Forward;

    private Button previousButton;

    public AudioSource audio;

    public AudioClip select;
    public AudioClip gasAudio;
    public AudioClip solidAudio;
    public AudioClip liquidAudio;
    public AudioClip animalAudio;
    public AudioClip plasmaAudio;

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
                    if(type.myState == Type.State.Gas)
                    {
                        audio.clip = gasAudio;
                    }
                    if (type.myState == Type.State.Liquid)
                    {
                        audio.clip = liquidAudio;
                    }
                    if (type.myState == Type.State.Solid)
                    {
                        audio.clip = solidAudio;
                    }
                    if (type.myState == Type.State.Animal)
                    {
                        audio.clip = animalAudio;
                    }
                    if (type.myState == Type.State.Plasma)
                    {
                        audio.clip = plasmaAudio;
                    }

                    audio.Play();
                    hit.transform.gameObject.GetComponent<Tile>().IsClickedOn(type, brushSize);
                }
                //Debug.Log(hit.transform.name);
            }
        }
    }

    public void ElementSelected(Type t, Button b)
    {
        PlaySelect();
        if (previousButton != null)
        {
            previousButton.interactable = true;
        }
        previousButton = b;
        previousButton.interactable = false;
        type = t;
    }

    public void PausePressed()
    {
        PlaySelect();
        Time.timeScale = 0;
        Pause.interactable = false;
        Play.interactable = true;
        Forward.interactable = true;
    }
    public void PlayPressed()
    {
        PlaySelect();
        Time.timeScale = 1.0f;
        Pause.interactable = true;
        Play.interactable = false;
        Forward.interactable = true;
    }
    public void SpeedUpPressed()
    {
        PlaySelect();
        Time.timeScale = 2f;
        Pause.interactable = true;
        Play.interactable = true;
        Forward.interactable = false;
    }

    public void BrushButtonPressed1()
    {
        PlaySelect();
        brushSize = 1;
        brush1.interactable = false;
        brush2.interactable = true;
        brush3.interactable = true;
    }
    public void BrushButtonPressed2()
    {
        PlaySelect();
        brushSize = 2;
        brush1.interactable = true;
        brush2.interactable = false;
        brush3.interactable = true;
    }
    public void BrushButtonPressed3()
    {
        PlaySelect();
        brushSize = 3;
        brush1.interactable = true;
        brush2.interactable = true;
        brush3.interactable = false;
    }

    public void PlaySelect()
    {
        audio.clip = select;
        audio.Play();
    }
}
