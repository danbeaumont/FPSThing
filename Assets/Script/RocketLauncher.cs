using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public bool playerControlled = true;        // Is the RocketLauncher is controlled the player?
    public float fireInterval = 3.0f;           // How many seconds between shots for the Rocket Launcher
    private float fireTimer = 0;                // Use this timer to see if we can fire again
    public GameObject rocketPrefab;             // A reference to the rocket prefab so we can spawn it
    public Vector3 spawnOffset;                 // A position offset for where the rocket is spawned on the gun so that rockets dont spawn in the gun
    public int ammo = 5;                        // how many rockets does the player have?

    public GameObject spawnPoint;               // a reference to an invisible gameobject that determines where to shoot the rocket from
    
    // Start is called before the first frame update
    void Start()
    {
        fireTimer = fireInterval;              // We should start ready to shoot
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;            // Advance our timer

        if (fireTimer >= fireInterval)          // Have we waited long enough to fire the gun again?
        {   
            // if we are player controlled, ha the fire button been pressed?
            if (playerControlled && Input.GetButtonDown("Fire1"))
            {
                Fire();
            }
        }
    }

    public void Fire()
    {
        // only shoot if we have ammo
        if (ammo <= 0)
        {
            return;
        }

        // Spawn a rocket prefab
        GameObject rocketInstance = Instantiate(rocketPrefab);

        // move the rocket to our spawn point location
        rocketInstance.transform.position = spawnPoint.transform.position;
        
        // move our rocket to the desired spawn offset
        //rocketInstance.transform.position = transform.position + transform.right * spawnOffset.x + transform.up * spawnOffset.y + transform.forward * spawnOffset.z;

        // rotate the rocket to match the gun rotation
        rocketInstance.transform.rotation = transform.rotation;

        // reset the shoot timer
        fireTimer = 0f;

        // subtract from our ammo
        ammo -= 1;
    }
}
