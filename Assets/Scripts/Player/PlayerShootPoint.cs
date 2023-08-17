using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerShootPoint : MonoBehaviour
{
    public AudioMixerSnapshot audioSnapshootNormal;
    public AudioMixerSnapshot audioSnapshootExplosion;
    public AudioSource audioPistolShoot;
    public AudioSource audioBombShoot;

    public bool canShoot = true;
    public GameObject PrefabBullet;
    public bool canBomb = true;
    public GameObject PrefabBomb;
    public Light bangEffect;

    public Weapons weapons;

    int counter = 0;

    void ShootBullet()
    {
        GameObject bullet = Instantiate(PrefabBullet, transform.position, transform.rotation);
        if (bangEffect) { Instantiate(bangEffect, transform.position, transform.rotation, transform); }
        bullet.gameObject.name = "bullet " + counter;
        counter++;

        if (audioPistolShoot != null)
        { audioPistolShoot.Play(); }
    }
    void ShootBomb()
    {
        GameObject bomb = Instantiate(PrefabBomb, transform.position + transform.forward, transform.rotation);
        bomb.gameObject.name = "bullet " + counter;

        if (audioBombShoot != null)
        { audioBombShoot.Play(); }
    }

    void Update()
    {
        if (canShoot)
        {
            //bala
            if (Input.GetButtonDown("Shoot") && weapons.GunRounds > 0)
            {
                //disparar cada medio segundo en caso de un rifle con atenuacion de sonido
                //InvokeRepeating(nameof(ShootBullet), 0, 0.2f);
                //audioSnapshootExplosion.TransitionTo(3);

                Invoke(nameof(ShootBullet), 0);

                weapons.GunRounds--;
            }
            /* PARA IMPLEMENTAR: rifle automatico
            if (weapons.isRifle)
            {
                if (Input.GetButtonUp("DispararBala"))
                {
                    CancelInvoke(nameof(ShootBullet));
                    audioSnapshootNormal.TransitionTo(2);
                }
            }
            */
        }
        if (canBomb && weapons.hasDynamite && weapons.BombsRounds > 0)
        {
            //bomba
            if (Input.GetButtonDown("DispararBomba"))
            {
                Invoke(nameof(ShootBomb), 0);
                weapons.BombsRounds--;
                
            }
            if (weapons.BombsRounds <= 0)
            {
                weapons.hasDynamite = false;
                weapons.SetWeapon(1);
            }
        }
    }
}
