using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyZone : MonoBehaviour
{
    Transform mask;
    Vector3 offset;
    float radius;
    // Start is called before the first frame update
    void Start()
    {
        mask = GameObject.Find("Camera").transform;
        offset = GameObject.Find("Controller (left)").GetComponent<Movement>().maskOffset;
        radius = GameObject.Find("Controller (left)").GetComponent<Movement>().radius;
        this.GetComponent<SphereCollider>().radius = radius;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mask.position + offset;
    }
}
