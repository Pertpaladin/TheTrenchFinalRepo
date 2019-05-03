using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public string RigidbodyObjectName;
    public int FramesPerCheck = 1; // frames between checks
    int frameCheck = 0;
    int buttonPress = 1;
    int scale = 30000;
    int angularscale = 200;
    float wiggleRoom = 1f;
    Rigidbody rb;
    GameObject rbParent;
    GameObject mask;
    public Vector3 maskOffset;
    public float radius = 0.5f;


    bool InSafezone = true;
    bool Forward = false;
    bool Backward = false;
    bool Upward = false;
    bool Downward = false;
    bool AllowMotion;

    Queue<Vector3> Locations;
    Vector3[] LocationsArray;
    Vector3 Previous;
    Vector3 referencePoint;
    

    int state;
    // Use this for initialization
    void Start () {
        Locations = new Queue<Vector3>();
        mask = GameObject.Find("Camera");
        maskOffset = new Vector3(0, -0.50f, 0) + new Vector3 (mask.transform.forward.x, 0, mask.transform.forward.z).normalized * 0.1f ;
        referencePoint = mask.transform.position - maskOffset;
        rbParent = GameObject.Find(RigidbodyObjectName);
        rb = rbParent.GetComponent<Rigidbody>();
        state = 0;
        AllowMotion = false;
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if buttonDown{
            buttonPress = 3
        else
            buttonPress = 3
        }
        */
        Debug.Log(state);
        //Debug.Log("Locations Count: " + Locations.Count);
        InSafezone = CheckInSafetyZone();
        referencePoint = mask.transform.position + maskOffset;// + -0.15f * new Vector3(mask.transform.forward.x, 0, mask.transform.forward.z);
        switch (state)
        {
            case 0:
                //initial state, check for trend
                Locations.Enqueue(transform.position - referencePoint);
                if(Locations.Count > 15)
                {
                    Locations.Dequeue();

                }
                LocationsArray = Locations.ToArray();
                for (int i = 1; i < Locations.Count; i++)
                {
                    if (LocationsArray[i].y - LocationsArray[i - 1].y>= 0.01f)
                    {
                        Upward = true;
                    }
                    else
                    {
                        Upward = false;
                        break;
                    }
                }
                for (int i = 1; i < Locations.Count; i++)
                {
                    if (LocationsArray[i-1].y - LocationsArray[i].y >= 0.01f)
                    {
                        Downward = true;
                    }
                    else
                    {
                        Downward = false;
                        break;
                    }
                }
                for (int i = 1; i < Locations.Count; i++)
                {
                    if (/*sLocationsArray[i].z - LocationsArray[i - 1].z <= 0 || */LocationsArray[i].x * LocationsArray[i].x - LocationsArray[i - 1].x * LocationsArray[i - 1].x >= 0)
                    {
                        Backward = true;
                    }
                    else
                    {
                        Backward = false;
                        break;
                    }
                }
                for (int i = 1; i < Locations.Count; i++)
                {
                    if (LocationsArray[i].z - LocationsArray[i - 1].z >= 0)
                    {
                        Forward = true;
                    }
                    else
                    {
                        Forward = false;
                        break;
                    }
                }
                state = 42;
                if (Backward && Locations.Count >= 10 && !InSafezone) //&& Out of Safety Zone
                {
                    state = -1;
                }
                if (Forward && Locations.Count >= 10 && !InSafezone) //&& Out of Safety Zone
                {
                    state = 1;
                }
                if (Upward && Locations.Count >= 10 && !InSafezone) //&& Out of Safety Zone
                {
                    state = 5;
                }
                if (Downward && Locations.Count >= 10 && !InSafezone) //&& Out of Safety Zone
                {
                    state = -5;
                }

                Previous = transform.position - referencePoint;
                break;

            case 1:
                if (InSafezone)
                {
                    state = 0;
                    Locations.Clear();
                    break;
                }
                if (Previous.z >= (transform.position - referencePoint).z)
                {
                    StartCoroutine(EndMotion());
                    state = 2;
                    rb.AddForce(scale * buttonPress * (Previous - (transform.position - referencePoint)));
                    rb.AddTorque(0,(scale / angularscale * (Previous - (transform.position - referencePoint))).y, 0);
                    /*sound*/
                }
                Previous = transform.position - referencePoint;
                break;
            case 2:
                if (InSafezone)
                {
                    state = 0;
                    Locations.Clear();
                    break;
                }
                //if in safety zone
                //state = 0, clear queue and break
                if (Previous.x * Previous.x + wiggleRoom * wiggleRoom > (transform.position- referencePoint).x * (transform.position- referencePoint).x)
                {
                    state = 1;
                } else if (false)
                {
                    rb.AddForce(scale * buttonPress * (Previous - (transform.position - referencePoint)));
                    rb.AddTorque(0, (scale / angularscale * (Previous - (transform.position - referencePoint))).y, 0);

                    Debug.Log("Move!");
                }
                Previous = transform.position - referencePoint;
                break;
            case 5:
                if (InSafezone)
                {
                    state = 0;
                    Locations.Clear();
                    break;
                }
                if (Previous.y >= (transform.position - referencePoint).y)
                {
                    StartCoroutine(EndMotion());
                    state = 6;
                    rb.AddForce(scale * buttonPress * (Previous - (transform.position - referencePoint)));
                    rb.AddTorque(0,(scale / angularscale * (Previous - (transform.position - referencePoint))).y, 0);
                    /*sound*/
                }
                Previous = transform.position - referencePoint;
                break;
            case 6:
                if (InSafezone)
                {
                    state = 0;
                    Locations.Clear();
                    break;
                }
                //if in safety zone
                //state = 0, clear queue and break
                if (Previous.x * Previous.x + wiggleRoom * wiggleRoom > (transform.position- referencePoint).x * (transform.position- referencePoint).x)
                {
                    state = 5;
                } else if (false)
                {
                    rb.AddForce(scale * buttonPress * (Previous - (transform.position - referencePoint)));
                    rb.AddTorque(0, (scale / angularscale * (Previous - (transform.position - referencePoint))).y, 0);

                    Debug.Log("Move!");
                }
                Previous = transform.position - referencePoint;
                break;
            case -5:
                if (InSafezone)
                {
                    state = 0;
                    Locations.Clear();
                    break;
                }
                if (Previous.y <= (transform.position - referencePoint).y)
                {
                    StartCoroutine(EndMotion());
                    state = -6;
                    rb.AddForce(scale * buttonPress * (Previous - (transform.position - referencePoint)));
                    rb.AddTorque(0,(scale / angularscale * (Previous - (transform.position - referencePoint))).y, 0);
                    /*sound*/
                }
                Previous = transform.position - referencePoint;
                break;
            case -6:
                if (InSafezone)
                {
                    state = 0;
                    Locations.Clear();
                    break;
                }
                //if in safety zone
                //state = 0, clear queue and break
                if (//Previous.x * Previous.x + wiggleRoom * wiggleRoom > (transform.position- referencePoint).x * (transform.position- referencePoint).x)
                Previous.y + wiggleRoom > (transform.position - referencePoint).y
                    )
                {
                    state = -5;
                } else if (false)
                {
                    rb.AddForce(scale * buttonPress * (Previous - (transform.position - referencePoint)));
                    rb.AddTorque(0, (scale / angularscale * (Previous - (transform.position - referencePoint))).y, 0);

                    Debug.Log("Move!");
                }
                Previous = transform.position - referencePoint;
                break;
            
            case -1:
                if (InSafezone)
                {
                    state = 0;
                    Locations.Clear();
                    break;
                }
                
                if (Previous.z <= (transform.position- referencePoint).z)//|| Previous.x * Previous.x < transform.position.x * transform.position.x)
                {
                    StartCoroutine(EndMotion());
                    state = -2;
                    rb.AddForce(scale * buttonPress * (Previous - (transform.position - referencePoint)));
                    rb.AddTorque(0, (scale / angularscale * (Previous - (transform.position - referencePoint))).y, 0);
                    /*sound*/

                }
                Previous = transform.position- referencePoint;
                break;
            case -2:
                if (InSafezone)
                {
                    state = 0;
                    Locations.Clear();
                    break;
                }
                if (Previous.z + wiggleRoom >= (transform.position- referencePoint).z)
                {
                    state = -1;
                }
                else if(false)
                {
                    rb.AddForce(scale * buttonPress * (Previous - (transform.position -referencePoint)));
                    rb.AddTorque(0, (scale / angularscale * (Previous - (transform.position - referencePoint))).y, 0);
                    


                    Debug.Log("Move!");
                }
                Previous = transform.position - referencePoint;
                break;
            case 42:
                //stall for case 0 to not check every frame
                frameCheck++;
                if(frameCheck >= FramesPerCheck)
                {
                    state = 0;
                    frameCheck = 0;
                }
                break;
        }
    }
    bool CheckInSafetyZone()
    {
        /*
        if (Downward||state == -5||state==-6){
            if((transform.position-referencePoint).magnitude < 0.35){
                return true;
            }
            else{
                return false;
            }
        } */
        if (Mathf.Abs(transform.position.x-referencePoint.x) < radius * 1.5 && Mathf.Abs(transform.position.z - referencePoint.z) < radius*0.75f && Mathf.Abs(transform.position.y - referencePoint .y) < radius * 2)
        {
            return true;
        }
        return false;
    }
    IEnumerator EndMotion()
    {
        //AllowMotion = true;
        //yield return new WaitForSeconds(0.5f);
        //AllowMotion = false;
        yield return new WaitForSeconds(0);
    }
}
