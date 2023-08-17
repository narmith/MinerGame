using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{
    public float bonus = 5f;
    public bool consumed = false;

    void OnTriggerEnter(Collider other)
    {
        //check si el otro gameObject tiene el componente que deseamos
        if (other.gameObject.TryGetComponent(out Vida _vida) && !consumed)
        {
            if (_vida.currentHealth != _vida.maxHealth)
            {
                _vida.GetHealed(10);
                consumed = true;
            }
        }
    }
}
