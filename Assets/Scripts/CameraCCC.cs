using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCCC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.GetComponent(Weapon) != null)
        //   collision.gameObject.GetComponent((Weapon).;
        //Destroy(collision.gameObject);
        //Debug.Log("::::" + collision.gameObject.name);
        Debug.Log("::::-->" + collision.gameObject.GetComponent<WeaponCCC>().getWeapon());
        if (collision.gameObject.GetComponent<WeaponCCC>() != null)
        {
            Debug.Log("::::" + collision.gameObject.GetComponent<WeaponCCC>().getWeapon());
        }



    }
}
