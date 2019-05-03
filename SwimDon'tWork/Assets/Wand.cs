using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour {

    float mouseX;
    float mouseY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        mouseX = Input.mousePosition.x / Screen.width;
        mouseY = Input.mousePosition.y / Screen.height;

        float yf = (float)-75f * (mouseY - .5f) + 90f;
        float xf = (float) 75f * (mouseX - .5f);

        transform.localEulerAngles = new Vector3(yf, xf, 0f);

    }
}
