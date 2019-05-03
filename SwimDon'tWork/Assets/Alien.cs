using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alien : MonoBehaviour
{

    [SerializeField] float f = 0.25f;
    [SerializeField] float ff = 0.25f;

    [SerializeField] GameObject T1;
    [SerializeField] GameObject T2;

    [SerializeField] GameObject H1;
    [SerializeField] GameObject H2;
    [SerializeField] GameObject H3;

    [SerializeField] GameObject E1;
    [SerializeField] GameObject E2;
    [SerializeField] GameObject E3;
    [SerializeField] GameObject E4;



    [SerializeField] GameObject T3;
    [SerializeField] GameObject T4;

    [SerializeField] GameObject R1;
    [SerializeField] GameObject R2;
    [SerializeField] GameObject R3;
    [SerializeField] GameObject R4;
    [SerializeField] GameObject R5;

    [SerializeField] GameObject E5;
    [SerializeField] GameObject E6;
    [SerializeField] GameObject E7;
    [SerializeField] GameObject E8;

    [SerializeField] GameObject N1;
    [SerializeField] GameObject N2;
    [SerializeField] GameObject N3;

    [SerializeField] GameObject C1;
    [SerializeField] GameObject C2;
    [SerializeField] GameObject C3;

    [SerializeField] GameObject H4;
    [SerializeField] GameObject H5;
    [SerializeField] GameObject H6;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(alien());
    }

    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator alien()
    {
        yield return new WaitForSeconds(1.5f);

        T1.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        T2.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        T3.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        T4.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        E1.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        E2.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        E3.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        E4.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        E5.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        E6.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        E7.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        E8.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        H1.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        H2.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        H3.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        H4.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        H5.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        H6.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        R1.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        R2.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        R3.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        R4.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        R5.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        C1.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        C2.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        C3.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        N1.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        N2.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
        N3.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);


        yield return new WaitForSeconds(1f);

        yield return new WaitForSeconds(f);
        T1.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        T2.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        H1.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        H2.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        H3.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        E1.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        E2.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        E3.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        E4.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        T3.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        T4.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        R1.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        R2.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        R3.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        R4.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        R5.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        E5.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        E6.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        E7.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        E8.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        N1.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        N2.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        N3.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        C1.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        C2.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        C3.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        H4.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        H5.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);
        H6.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(f);



    }

}
