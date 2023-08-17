using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public int damage = 20;
    public GameObject impactEffect;
    public Color targetOriginalColor;

    void ChangeColor(GameObject _target, Color _newColor)
    {
        if (_target.gameObject.GetComponent<Renderer>() != null)
        {
            if (_target.gameObject.CompareTag("Destructible") || _target.gameObject.CompareTag("Enemy"))
            {
                targetOriginalColor = _target.gameObject.GetComponent<Renderer>().material.color;
                _target.gameObject.GetComponent<Renderer>().material.color = _newColor;
            }
        }
    }
    void ResetColor(GameObject _target)
    {
        if (_target.gameObject.GetComponent<Renderer>() != null)
        {
            if (_target.gameObject.CompareTag("Destructible") || _target.gameObject.CompareTag("Enemy"))
            {
                _target.gameObject.GetComponent<Renderer>().material.color = targetOriginalColor;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        ChangeColor(other.gameObject, Color.green);
    }

    void OnTriggerStay(Collider other)
    {
        

        if (Input.GetButtonDown("Shoot"))
        {
            if (other.gameObject.CompareTag("Destructible") || other.gameObject.CompareTag("Enemy"))
            {
                if (other.gameObject.TryGetComponent(out Vida otherVida))
                {
                    otherVida.TakeDamage(damage);
                }
                Instantiate(impactEffect, transform.position, transform.rotation);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        ResetColor(other.gameObject);
    }
}