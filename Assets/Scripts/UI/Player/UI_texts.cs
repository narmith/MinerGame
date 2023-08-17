using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_texts : MonoBehaviour
{
    public Weapons current_weapon;
    public Vida playerHealth;
    public Text bulletText;
    public Text bombText;
    public Text godText;

    void CurrentWeaponsText(int num)
    {
        if(num==3) //gun
        {
            bombText.enabled = false;
            bulletText.enabled = true;
        }
        else if(num==4) //bomb
        {
            bombText.enabled = true;
            bulletText.enabled = false;
        }
        else if(num==0) //no weapons
        {
            bombText.enabled = false;
            bulletText.enabled = false;
        }

        if(playerHealth.godMode==true)
        {
            godText.enabled = true;
        }
        else if(playerHealth.godMode == false)
        {
            godText.enabled = false;
        }
    }

    void Update()
    {
        if (current_weapon.CurrentWeapon == 3) //gun
        {
            CurrentWeaponsText(3);
            bulletText.text = "Bullets: " + current_weapon.GunRounds;
        }
        else if (current_weapon.CurrentWeapon == 4) //bomb
        {
            CurrentWeaponsText(4);
            bombText.text = "Bombs: " + current_weapon.BombsRounds;
        }
        else CurrentWeaponsText(0);
    }
}
