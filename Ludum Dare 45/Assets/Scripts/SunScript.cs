using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunScript : MonoBehaviour {

    public float RotateSpeed = 5f;
    public float Radius = 5f;

    private Vector2 _centre;
    private float _angle;

    public Camera camera;

    public Color dayColor;
    public Color nightColor;


    private Color curentColor;
    private Color nextColor;

    public float dur;
    private float t = 0;

    private bool first = true;
    private float timer = 0;

    public Text text;
    private int day = 0;

    //v = 2 × π × r / t

    private void Start()
    {
        curentColor = dayColor;
        nextColor = nightColor;
        _centre = transform.position;
    }

    private void Update()
    {
        if (first)
        {
            timer += Time.deltaTime;
            if(transform.position.y <= 0.000001f - Radius)
            {
                first = false;
                dur = timer;
            }
        }
        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;

        camera.backgroundColor = Color.Lerp(curentColor, nextColor, t);
        if(t< 1){
            t += Time.deltaTime / dur;
        }
        else
        {
            if (camera.backgroundColor == dayColor)
            {
                curentColor = dayColor;
                nextColor = nightColor;
            }

            if (camera.backgroundColor == nightColor)
            {
                day++;
                text.text = "Day: " + day;
                curentColor = nightColor;
                nextColor = dayColor;
            }
            t = 0;

        }
        
    }
}
