using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementButtonScript : MonoBehaviour {

    public Text nameLabel;
    public Image map;
    public Button button;
    private InputHandler handler;
    private Type type;


    // Use this for initialization
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    public void Setup(Type t, InputHandler ihand)
    {
        type = t;
        nameLabel.text = type.typeName;


        map.sprite = type.icon;
        

        handler = ihand;
    }

    void TaskOnClick()
    {
        handler.ElementSelected(type, button);
    }

}
