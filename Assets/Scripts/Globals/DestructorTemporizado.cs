using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorTemporizado : MonoBehaviour
{
    public float timeAlive=5f;

    void Awake()
    {
        Invoke("Destruirse", timeAlive);
    }
    void Destruirse()
    {
        Destroy(this.gameObject);
    }
}
