using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCCC : MonoBehaviour
{
    public GameObject explotion;

    public GameObject bulletDecal;
    private void OnCollisionEnter(Collision collision)
    {
        
        //informacion de 
        Instantiate(explotion, collision.contacts[0].point, Quaternion.identity);
        Vector3 startPos = collision.contacts[0].point;
        Vector3 addV = collision.contacts[0].normal * 0.01f;
        Quaternion startRot = Quaternion.LookRotation(addV *-1);
        
        Instantiate(bulletDecal, startPos + addV, startRot);

        Destroy(this.gameObject);

        //Debug.Log("::::" + collision.);
        
    }
}
