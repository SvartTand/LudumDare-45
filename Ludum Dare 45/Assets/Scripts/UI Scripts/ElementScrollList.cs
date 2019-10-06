using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementScrollList : MonoBehaviour {

    public GameObject buttonPrefab;
    public ListOfTypes list;
    public InputHandler inputHandler;
    public bool unlocks;

    // Use this for initialization
    void Start()
    {

        
        for (int i = 0; i < list.types.Count; i++)
        {
            if(i != 2)
            {
                GameObject tempButton = GameObject.Instantiate(buttonPrefab, transform);
                tempButton.GetComponent<ElementButtonScript>().Setup(list.types[i], inputHandler);
                list.types[i].SetButton(tempButton.GetComponent<Button>());
                if(i > 3 && unlocks)
                {
                    tempButton.GetComponent<Button>().interactable = false;
                }
            }
            
        }
    }
}
