using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public PlayerShootPoint _shooter;
    public GameObject _hand;
    public GameObject _pickAxe;
    public GameObject _gun;
    public GameObject _dynamite;

    public bool hasHands = false;       // 1
    public bool hasPickAxe = false;     // 2
    public bool hasGun = false;         // 3
    public int GunRounds = 6;
    public bool hasDynamite = false;    // 4
    public int BombsRounds = 1;

    public int CurrentWeapon = 1;

    void Start()
    {
        if(_hand==null)
            { print("No existe el arma: Hand"); }
        if (_pickAxe == null)
            { print("No existe el arma: PickAxe"); }
        if (_gun == null)
            { print("No existe el arma: Gun"); }
        if (_dynamite == null)
            { print("No existe el arma: Dynamite"); }

        DeactivateWeapons();
        SetWeapon(1);
        CurrentWeapon = 1;
    }

    public void DeactivateWeapons()
    {
        if (_hand.activeSelf)
            _hand.SetActive(false);
        if (_pickAxe.activeSelf)
            _pickAxe.SetActive(false);
        if (_gun.activeSelf)
            _gun.SetActive(false);
        if (_dynamite.activeSelf)
            _dynamite.SetActive(false);

        _shooter.canShoot = false;
        _shooter.canBomb = false;
    }

    public void SetWeapon(int num)
    {
        DeactivateWeapons();

        if (num == 1)
        {
            _hand.SetActive(true);
            CurrentWeapon = 1;
        }
        if (num == 2)
        {
            _pickAxe.SetActive(true);
            CurrentWeapon = 2;
        }
        if (num == 3)
        {
            _gun.SetActive(true);
            _shooter.canShoot = true;
            CurrentWeapon = 3;
        }
        if (num == 4)
        {
            _dynamite.SetActive(true);
            _shooter.canBomb = true;
            CurrentWeapon = 4;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) && !_hand.activeSelf)
        {
            SetWeapon(1);
        }
        if (Input.GetKey(KeyCode.Alpha2) && !_pickAxe.activeSelf && hasPickAxe)
        {
            SetWeapon(2);
        }
        if (Input.GetKey(KeyCode.Alpha3) && !_gun.activeSelf && hasGun)
        {
            SetWeapon(3);
        }
        if (Input.GetKey(KeyCode.Alpha4) && !_dynamite.activeSelf && BombsRounds > 0)
        {
            SetWeapon(4);
        }
    }
}
