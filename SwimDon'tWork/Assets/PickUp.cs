using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {


    [SerializeField] Material col;
    [SerializeField] Color coll;
    [SerializeField] Color colll;

    // Use this for initialization
    void Start () {

        col = GetComponent<Renderer>().material;
        col.SetColor("_Color", Color.white);

    }
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetMouseButtonUp(0))
        {
            transform.parent = null;
            col.SetColor("_Color", coll);
        }

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wand")
        {
            col.SetColor("_Color", coll);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Wand")
        {
            if (Input.GetMouseButton(0))
            {
                col.SetColor("_Color", colll);
                transform.parent = other.transform;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Wand" && transform.parent == null)
        {
            col.SetColor("_Color", Color.white);
        }
    }

}
