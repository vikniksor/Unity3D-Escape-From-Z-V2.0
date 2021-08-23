using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera playerCamera;
    [Tooltip("Distance of shot.")]
    [SerializeField] float range = 100f;


    void Update()
    {
        if (Input.GetButton("Fire1")) { Shoot(); }
    }


    private void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, 
                        out hit, range);
        Debug.Log("I hit this thing: " + hit.transform.name);
    }
}
