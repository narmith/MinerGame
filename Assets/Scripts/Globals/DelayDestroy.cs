using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDestroy : MonoBehaviour
{
    public bool Destroyable=true;
    public GameObject Prefab;
    public float Speed = 5f;
    public float LiveSeconds = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LiveSeconds > 0)
        {
            Prefab.transform.Translate(new Vector3(0f,0f,1f) * Speed * Time.deltaTime);
            LiveSeconds -= 1 * Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
