using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour {

    private bool shake;

    private float shakeDuration = 0;
    private float shakeAmount = 0.7f;
    private Vector3 originalPos;

    private Vector3 realOrgPos;
    // Use this for initialization
    void Start () {
        realOrgPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (shake)
        {
            ShakeUpdate();
        }
    }

    private void ShakeUpdate()
    {
        originalPos = transform.localPosition;
        if (shakeDuration > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount * gameObject.GetComponent<Camera>().orthographicSize;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = realOrgPos;
            shake = false;
        }

    }

    public void Shake(float amount, float duration)
    {
        shake = true;
        shakeAmount = amount;
        shakeDuration = duration;

    }
}
