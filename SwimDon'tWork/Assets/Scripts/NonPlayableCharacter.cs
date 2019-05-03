using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonPlayableCharacter : MonoBehaviour {

    [SerializeField] GameObject interactionText;
    [SerializeField] GameObject savedText;

    [SerializeField] Color colorSolid;
    [SerializeField] Color colorMedium;
    [SerializeField] Color colorTransparent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        /*
         * If player enters the trigger zone of a character....
         * Text appears on screen showing that you can click a button to save the character
         */

        if(other.tag == "Player")
        {
            interactionText.SetActive(true);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        /*
        if(Player Clicks A Button)
        {
            //Character fades away because you 'saved' them
            StartCoroutine(showText());
        }
        */
    }

    private void OnTriggerExit(Collider other)
    {
        /*
         * If player leaves the trigger zone of a character....
         * Text disappears on screen showing that you can click a button to save the character
         */

        if (other.tag == "Player")
        {
            interactionText.SetActive(false);
        }

    }

    IEnumerator showText()
    {
        savedText.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        savedText.GetComponentInChildren<Text>().color = colorSolid;
        yield return new WaitForSeconds(0.5f);
        savedText.GetComponentInChildren<Text>().color = colorMedium;
        yield return new WaitForSeconds(0.5f);
        savedText.GetComponentInChildren<Text>().color = colorTransparent;
        yield return new WaitForSeconds(0.25f);
        savedText.SetActive(false);
    }

}
