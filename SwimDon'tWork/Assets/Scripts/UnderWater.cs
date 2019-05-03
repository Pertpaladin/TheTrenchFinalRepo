using UnityEngine;
using System.Collections;

public class UnderWater : MonoBehaviour
{
    public float waterHeight;

    [SerializeField] bool isUnderwater;

    public Color normalColor;
    public Color underwaterColor;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.y < waterHeight) != isUnderwater)
        {
            isUnderwater = transform.position.y < waterHeight;
            if (isUnderwater) SetUnderwater();
            if (!isUnderwater) SetNormal();
        }
    }

    void SetNormal()
    {
        RenderSettings.fog = true;
        RenderSettings.fogColor = normalColor;
        float f = Random.Range(0f, 0.002f);
        RenderSettings.fogDensity = f;

    }

    void SetUnderwater()
    {
        RenderSettings.fog = true;
        RenderSettings.fogColor = underwaterColor;
        //float n = Random.Range(0f,0.02f);
        //Debug.Log(n);
        RenderSettings.fogDensity = 0.0075f;

    }
}
