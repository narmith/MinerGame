using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLookAt : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        this.transform.LookAt(target.transform);
    }
}
