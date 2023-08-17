using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorAutomatico : MonoBehaviour
{
    public GameObject Prefab;
    int counter = 0;
    public bool _enabled = true;
    public Light bang;
    public float startDelay = 3f;
    public float shootFrecuency=2f;
    public AudioSource audioPistolShoot;
    public AudioSource audioBombShoot;

    private void Awake()
    {
        InvokeRepeating(nameof(Disparar), startDelay, shootFrecuency);
    }

    void Disparar()
    {
        if (_enabled != false)
        {
            GameObject bullet = Instantiate(Prefab, transform.position + transform.forward, transform.rotation);
            Instantiate(bang, transform.position + transform.forward, transform.rotation);
            bullet.gameObject.tag = "Enemy";
            bullet.gameObject.name = "bullet " + counter;
            counter++;

            if (audioPistolShoot != null)
                { audioPistolShoot.Play(); }
        }
    }
}
