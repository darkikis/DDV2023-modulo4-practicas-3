using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCCC : MonoBehaviour
{
    // Start is called before the first frame update

    private int weapon;

    public int initialWeapon;
    void Start()
    {
        weapon = initialWeapon;
    }

    public int getWeapon() {
        return weapon;
    }
}
