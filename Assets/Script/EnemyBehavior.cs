using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : EnemyProperties
{
    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TakeDamage(50f);
        }
    }
}
