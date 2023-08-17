using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject doorIzq;
    public GameObject doorDer;
    Vector3 posIzqOriginal;
    Vector3 posDerOriginal;
    public Vector3 dist = new Vector3(1, 0, 0);
    public string triggerTag="Player";
    public bool isBlocked=false;

    private void Start()
    {
        if (doorIzq.gameObject != null)
        {
            posIzqOriginal = doorIzq.transform.position;
        }
        if (doorDer.gameObject != null)
        {
            posDerOriginal = doorDer.transform.position;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (doorIzq != null && doorDer != null)
        {
            if (other.CompareTag(triggerTag) && isBlocked == false)
            {
                doorIzq.transform.Translate(dist * -1);
                doorDer.transform.Translate(dist);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (doorIzq.transform.position != posIzqOriginal)
        {
            doorIzq.transform.position = posIzqOriginal;
        }
        if (doorDer.transform.position != posDerOriginal)
        {
            doorDer.transform.position = posDerOriginal;
        }
    }
}
