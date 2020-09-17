using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    // the name of the weapon this should enable upon collection.
    public string weaponName = string.Empty;

    private void OnTriggerEnter(Collider other)
    {
        // does the GameObject that collided with this weapon pickup have a WeaponSelector component?
        WeaponSelector weaponSelector = other.gameObject.GetComponentInChildren<WeaponSelector>();

        // if there is a weaponselector, tell it to mark the matching weapon as collected
        if (weaponSelector != null)
        {
            weaponSelector.CollectWeapon(weaponName);
            gameObject.SetActive(false);
        }
    }
}
