using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAmmoPickup : MonoBehaviour
{
    public int amount = 5;          // how many rockets are in this crate

    private void OnTriggerEnter(Collider other)
    {
        // see if the GameObject that collided with this box has a RocketLauncher component attached to it
        RocketLauncher rocketLauncher = other.gameObject.GetComponentInChildren<RocketLauncher>();

        // if it does, then
        if (rocketLauncher != null)
        {
            // add some ammo to the rocket launcher
            rocketLauncher.ammo += amount;

            // deactivate ourselves
            gameObject.SetActive(false);
        }
    }
}
