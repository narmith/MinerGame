using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorOleadas : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject target;
    GameObject Zombie;

    private void Awake()
    {
        Invoke("GenerarZombie", 0);
    }
    void GenerarZombie()
    {
        Zombie = Instantiate(Prefab, transform.position, transform.rotation);
        Zombie.gameObject.GetComponent<EnemyLookAt>().enemyTarget = target;
    }

    private void Update()
    {
        if (!Zombie)
        {
            GenerarZombie();
        }
    }
}
