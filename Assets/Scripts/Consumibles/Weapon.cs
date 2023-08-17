using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool isPickaxe = false;
    public bool isAmmo = false;
    public bool isGun = false;
    public int ammoCant = 18;
    public int bombsCant = 2;
    public bool isDynamite = false;

    void OnTriggerEnter(Collider other)
    {
        //check si el otro gameObject tiene el componente que deseamos
        if (other.gameObject.TryGetComponent(out Weapons _weapons))
        {
            if (isDynamite)
            {
                _weapons.hasDynamite = true;
                _weapons.BombsRounds += bombsCant;
                _weapons.SetWeapon(4);
                Destroy(this.gameObject);
            }
            if (isPickaxe && !_weapons.hasPickAxe)
            {
                _weapons.hasPickAxe = true;
                _weapons.SetWeapon(2);
                Destroy(this.gameObject);
            }
            if(isGun && !_weapons.hasGun)
            {
                _weapons.hasGun = true;
                _weapons.GunRounds = ammoCant;
                _weapons.SetWeapon(3);
                Destroy(this.gameObject);
            }
            else if (isAmmo)
            {
                _weapons.GunRounds += ammoCant;
                Destroy(this.gameObject);
            }
        }
    }
}
