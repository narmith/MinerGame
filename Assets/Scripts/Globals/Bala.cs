using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Speed = 10f;

    void Update()
    {
        this.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}
