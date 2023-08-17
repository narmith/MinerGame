using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public int damage = 30;
    public float bombDistance = 500f;
    public bool explotar = false;
    public GameObject explosionEffect;
    public GameObject lightEffect;

    Renderer objectColor;
    float timedCounter = 0;

    void Explode()
    {
        explotar = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (explotar == true)
        {
            if (other.CompareTag("Player") || other.CompareTag("Enemy") || other.CompareTag("Destructible"))
            {
                if (other.gameObject.TryGetComponent(out Vida otherVida))
                {
                    otherVida.TakeDamage(damage);
                }
            }

            Instantiate(lightEffect, transform.position, transform.rotation);
            Instantiate(explosionEffect, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
    }

    void Awake()
    {
        objectColor = this.gameObject.GetComponent<Renderer>();
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bombDistance);
        Invoke("Explode", 3);
    }

    void Colorcito()
    {
        if (objectColor.material.color != Color.yellow)
        {
            objectColor.material.SetColor("_Color", Color.yellow);
        }
        else objectColor.material.SetColor("_Color", Color.red);

        timedCounter = 1f;
    }

    void Update()
    {
        /* ALTERNAR COLORES */
        if(gameObject!=null)
        {
            if (timedCounter <= 0)
            { Colorcito(); }
            else
            { timedCounter -= 3f * Time.deltaTime; } //frecuencia (mas grande el float, mas rapido)
        }
        /* --- */
    }
}
