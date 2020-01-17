using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    public bool isBullet;

    [Header("BULLET SETTINGS")]
    public int bulletDamage = 50;
    public float bulletSpeed = 80;
    public float bulletLifetime = 2;

    // PRIVATE VARIABLES
    int ammoDamage;
    float ammoSpeed;
    float ammoLifetime;


    private void Awake()
    {
        if (isBullet == true)
        {
            ammoDamage = bulletDamage;
            ammoSpeed = bulletSpeed;
            ammoLifetime = bulletLifetime;
        }
    }

    void Start()
    {
        // Gives the bullet forward force when it's instantiated
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * ammoSpeed, ForceMode.Impulse);

        // Destroy the bullet after an amount of time
        Destroy(gameObject, ammoLifetime);
    }

    void OnCollisionEnter(Collision other)
    {
        // Create a variable of type 'EnemyHealth' and store the EnemyHealth script in it
        EnemyHealth enemyHealthScript = other.gameObject.GetComponentInParent<EnemyHealth>();

        // If the thing that this bullet hits has an EnemyHealth script..
        // (avoids errors when hitting non-player objects, like walls)
        if (enemyHealthScript)
        {
            // Run the EnemyHealth script's 'TakeDamage' method.
            // and deliver the value of 'ammoDamage'
            enemyHealthScript.TakeDamage(ammoDamage);
        }
        

        // Destroy the bullet
        Destroy(gameObject);
    }
}
