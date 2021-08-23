using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera playerCamera;
    [Tooltip("Distance of shot.")]
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;


    void Update()
    {
        if (Input.GetButton("Fire1")) { Shoot(); }
    }


    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, 
                        out hit, range))
        {
            Debug.Log("I hit this thing: " + hit.transform.name);
            //TODO: add some hit effect for visual players
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else { return; }
    }
}
