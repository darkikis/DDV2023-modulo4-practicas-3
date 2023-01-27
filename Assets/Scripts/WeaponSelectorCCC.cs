using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectorCCC : MonoBehaviour
{
    private Ray mouserRay;

    private RaycastHit mouseHit;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            mouserRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouserRay, out mouseHit)) { 
                
            }
        }
    }
}
