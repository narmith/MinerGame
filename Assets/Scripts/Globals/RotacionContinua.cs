using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionContinua : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotacionX;
    public float rotacionY;
    public float rotacionZ;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(   rotacionX * Time.deltaTime,
                            rotacionY * Time.deltaTime,
                            rotacionZ * Time.deltaTime);
    }
}
