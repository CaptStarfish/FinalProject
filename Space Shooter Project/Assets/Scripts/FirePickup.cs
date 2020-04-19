using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePickup : MonoBehaviour
{

    public float RFBoostValue = 0.005f;

    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Pickup")
        {
            Destroy(other.gameObject);
            //PlayerShooting.timeBetweenBullets -= RFBoostValue;
        }
    }
}
