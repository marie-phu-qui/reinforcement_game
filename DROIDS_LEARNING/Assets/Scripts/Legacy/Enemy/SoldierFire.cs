using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFire : MonoBehaviour
{
    [Header("SOLDIER SETTINGS")]
    public float timeBetweenBullets = 0.5f;
    public float effectsDisplayTime = 0.06f;
    public float lineRange = 50f;

    [Header("PUBLIC REFERENCES")]
    public Transform bulletOrigin;      // Where to instantiate bullet
    public Transform particleOrigin;    // Reference to particle orign
    public GameObject soldierBullet;    // Prefab
    public AudioClip gunSound;          // The cannon sound
    public GameObject impactEffect;     // The effect to spawn when the line hits something
    public GameObject statusLight;      // Reference to the turret's status light
    public Material statusLightRed;     // Reference to the red emissive material
    public Material statusLightGreen;   // Reference to the green emissive material
    public Material statusLightWhite;   // Reference to the white emissive material

    [Header("DEBUG")]
    public bool playerIsWithinRange;    // If player is close enough to shoot at

    // PRIVATE VARIABLES
    float timer;
    float effectsTimer;
    AudioSource audioSource;
    LineRenderer lineRenderer;      // Reference to the line renderer
    Ray shootRay = new Ray();       // A ray from the projectile origin forwards (Z)
    RaycastHit hitResult;           // A raycast hit that returns information about what it hit
    int shootableMask;              // Layer No. so that the line only hits shootable things
    int playerMask;                 // Layer No. so that the line also hits the player

    private void Awake()
    {
        // Give audioSource a value
        audioSource = bulletOrigin.GetComponent<AudioSource>();

        //Give lineRenderer a value 
        lineRenderer = particleOrigin.GetComponent<LineRenderer>();

        // Give shootableMask a value (returns the number of our 'Shootable' layer)
        shootableMask = LayerMask.GetMask("Shootable");

        // Give playerMask a value (returns the number of our 'Player' layer)
        playerMask = LayerMask.GetMask("Player");
    }


    private void Start()
    {
        // Set the status light to green
        statusLight.GetComponent<Renderer>().material = statusLightGreen;
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;            // counts up 
        effectsTimer -= Time.deltaTime;     // counts down

        // If the player is within range
        if (playerIsWithinRange == true && timer >= timeBetweenBullets)
        {
            // Set 'gunSound' as the current audio clip
            audioSource.clip = gunSound;

            // .. call the 'fire' method (below)
            FireBullet();

            // reset the bullet timer
            timer = 0;

            // start the effects timer
            effectsTimer = effectsDisplayTime;
        }

        // Effects timer
        if (effectsTimer <= 0)
        {
            // Disable light
            DisableEffects();
        }

        // If the player is dead, consider it to be 'out of range'
        if (GameObject.FindWithTag("Player").GetComponent<PlayerDeath>().playerIsDead == true)
        {
            playerIsWithinRange = false;
        }

    }

    public void playerInRangeTrue()
    {
        playerIsWithinRange = true;

        // Set the status light to red
        statusLight.GetComponent<Renderer>().material = statusLightRed;
    }

    public void playerInRangeFalse()
    {
        playerIsWithinRange = false;

        // Set the status light to green
        statusLight.GetComponent<Renderer>().material = statusLightGreen;
    }


    void FireBullet()
    {
        // Instantiate the bullet at the point of origin
        Instantiate(soldierBullet, bulletOrigin.position, bulletOrigin.rotation);

        // Stop the particle system (if it's already playing)
        particleOrigin.GetComponent<ParticleSystem>().Stop();

        // Play the particle system
        particleOrigin.GetComponent<ParticleSystem>().Play();

        // Turn on the light
        particleOrigin.GetComponent<Light>().enabled = true;

        // Turn on the line renderer
        lineRenderer.enabled = true;

        // Set the point at which to begin drawing the line
        lineRenderer.SetPosition(0, particleOrigin.position);

        // Set the point at which to begin the raycast
        shootRay.origin = particleOrigin.position;

        // Set the direction for the raycast
        shootRay.direction = particleOrigin.forward;

        // If the raycast hits something
        if (Physics.Raycast(shootRay, out hitResult, lineRange, shootableMask) || Physics.Raycast(shootRay, out hitResult, lineRange, playerMask))
        {
            // Set the end position of the line to be the point where the raycast hit
            lineRenderer.SetPosition(1, hitResult.point);

            // Instantiate the bullet impact effect at the point of impact
            // NOTE: impact effect contains audio source
            Instantiate(impactEffect, hitResult.point, Quaternion.identity);
        }

        else // If turret doesn't hit anything
        {
            // Draw a 100-unit line (lineRange) in the forward direction
            lineRenderer.SetPosition(1, shootRay.origin + shootRay.direction * lineRange);
        }

        // Play the BANG sound
        audioSource.Play();
    }

    void DisableEffects()
    {
        // Turn off the light
        particleOrigin.GetComponent<Light>().enabled = false;

        // Turn off the line renderer
        lineRenderer.enabled = false;
    }

 
}
