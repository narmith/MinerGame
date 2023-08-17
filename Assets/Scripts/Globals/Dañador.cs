using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dañador : MonoBehaviour
{
    public int damage = 10;
    public GameObject impactEffect;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Vida otherVida))
        {
            otherVida.TakeDamage(damage);
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Environment")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}


