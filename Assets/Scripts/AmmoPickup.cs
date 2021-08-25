using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player") 
        { 
            Debug.Log("Player did wut player do");
            Destroy(gameObject);
        }
    }
}
