using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour
{
    int OxygenLevel = 600;
    int OxygenDisplayLevel;
    int injured;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OxygenDownSteady());
    }

    // Update is called once per frame
    void Update()
    {
        if(OxygenLevel <= 0)
        {
            /*Game Over*/
        }
        OxygenDisplayLevel = OxygenLevel / 5;
        if(false/*Trigger down*/)
        {
            StartCoroutine(OxygenDownFast());
        }
        if(false/*Trigger down and A button Down*/)
        {
            //air cannon
        }
    }
    IEnumerator OxygenDownSteady()
    {
        while(OxygenLevel > 0)
        {
            OxygenLevel -= 1 * injured;
            yield return new  WaitForSeconds(1);
        }
    }
    IEnumerator OxygenDownFast()
    {
        while (false/*trigger*/)
        {
            OxygenLevel -= 4 * injured;
            yield return new WaitForSeconds(1);
        }
    }
    public void Injure()
    {
        injured = 2;
    }
    public void Heal()
    {
        injured = 1;
    }
}
