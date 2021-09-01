using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    
    [SerializeField] float intensityAmount = 1f;
    [SerializeField] float restorAngle = 90f;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restorAngle);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightIntensity(intensityAmount);

            Destroy(gameObject);
        }
    }
}
