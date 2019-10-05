using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementScrollList : MonoBehaviour {

    public GameObject buttonPrefab;
    public ListOfTypes list;
    public InputHandler inputHandler;

    // Use this for initialization
    void Start()
    {

        
        for (int i = 0; i < list.types.Count; i++)
        {
            GameObject tempButton = GameObject.Instantiate(buttonPrefab, transform);
            tempButton.GetComponent<ElementButtonScript>().Setup(list.types[i], inputHandler);
        }
    }
}
