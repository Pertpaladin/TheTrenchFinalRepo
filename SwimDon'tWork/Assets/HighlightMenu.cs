using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;

public class HighlightMenu : MonoBehaviour
{


    [SerializeField] Color col1;
    [SerializeField] Color col2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
        if(other.tag == "Wand")
        {
            GetComponent<Image>().color = col2;

            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (other.tag == "Wand")
        {
            GetComponent<Image>().color = col1;
        }
    }

}
