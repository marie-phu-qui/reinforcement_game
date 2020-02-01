using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("GENERAL SETTINGS")]
    public float displayRedLightTime = 2.0f;

    [Header("BULLET SETTINGS")]
    public float timeBetweenBullets = 0.15f;
    public float bulletEffectsDisplayTime = 0.06f;
    public float lineRange = 100f;                      // Length of line drawn

    [Header("LANDMINE SETTINGS")]
    public float timeBetweenLandmines = 0.5f;

    [Header("PUBLIC REFERENCES")]
    public Transform bulletOrigin;
    public Transform mineOrigin;
    public Transform particleOrigin;
    public GameObject playerBullet;
    public GameObject playerMine;
    public AudioClip gunSound;
    public AudioClip landMineSound;
    public AudioClip outOfAmmoSound;
    public GameObject impactEffect;                     // What to instantiate where line hits shootable object
    public GameObject statusLight;                      // Reference to the turret's status light
    public Material statusLightRed;                     // Reference to the red emissive material
    public Material statusLightGreen;                   // Reference to the green emissive material
    public Material statusLightWhite;                   // Reference to the white emissive material

    [Header("DEBUG")]
    public bool playerHasBullets = true;
    public bool playerHasMines = true;

    // PRIVATE VARIABLES
    float timer;
    float effectsTimer;
    float statusLightTimer;
    AudioSource audioSource;
    LineRenderer lineRenderer;
    Ray shootRay = new Ray();                           // Raycast from ParticleOrigin forwards (Z axis)
    RaycastHit hitResult;                               // The object hit by the raycast?
    int shootableMask;                                  // Layer No. of 'Shootable' mask

    private void Start()
    {
        // Give 'audioSource' a value
        audioSource = bulletOrigin.GetComponent<AudioSource>();

        // Give 'lineRenderer' a value
        lineRenderer = particleOrigin.GetComponent<LineRenderer>();

        // Give 'shootableMask' a value - returns the number of the 'Shootable' layer
        shootableMask = LayerMask.GetMask("Shootable");

        // Set the status light to green
        statusLight.GetComponent<Renderer>().material = statusLightGreen;

        // Set duration of statusLightTimer
        statusLightTimer = displayRedLightTime;
    }


    void Update()
    {
        // Tie 'timer' to deltaTime
        timer += Time.deltaTime;            // counts up
        effectsTimer -= Time.deltaTime;     // counts down

        // If Fire1 input is received ..
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            // Set the status light to red
            statusLight.GetComponent<Renderer>().material = statusLightRed;

            // Tell the laser sight that player is firing
            gameObject.GetComponent<LaserSight>().playerIsShooting = true;

            // Reset timer for next bullet
            timer = 0;

            // start the effects timer
            effectsTimer = bulletEffectsDisplayTime;

            // Set 'gunSound' as the current audio clip
            audioSource.clip = gunSound;

            // Run the 'FireBullet' method
            FireBullet();
        }

        // If Fire2 input is received ..
        if (Input.GetButton("Fire2") && timer >= timeBetweenLandmines)
        {
            if (playerHasMines == true)
            {
                // Set 'landMineSound' as the current audio clip
                audioSource.clip = landMineSound;

                // Run the 'PlaceMine' method below
                PlaceMine();

                // reset bullet timer
                timer = 0;
            }

            else
            {
                // Set 'outOfAmmoSound' as the current audio clip
                audioSource.clip = outOfAmmoSound;

                // Play the outOfAmmoSound
                audioSource.Play();
            }
        }

        if (effectsTimer <= 0)
        {
            // Run DisableEffects method
            DisableEffects();
        }

        if (timer >= statusLightTimer)
        {
            // Set the status light to green
            statusLight.GetComponent<Renderer>().material = statusLightGreen;
        }

    }


    void FireBullet()
    {
        // Instantiate the bullet at the end of the gun
        Instantiate(playerBullet, bulletOrigin.position, bulletOrigin.rotation);

        // Stop the particle system (if it's already playing)
        particleOrigin.GetComponent<ParticleSystem>().Stop();

        // Play the particle system
        particleOrigin.GetComponent<ParticleSystem>().Play();

        // Turn on the light
        particleOrigin.GetComponent<Light>().enabled = true;

        // Play the gun sound
        audioSource.Play();

        // Turn on the line renderer
        lineRenderer.enabled = true;

        // Set the point at which to begin drawing the line
        lineRenderer.SetPosition(0, particleOrigin.position);

        // Set the point at which to begin the raycast
        shootRay.origin = particleOrigin.position;

        // Set the direction for the raycast
        shootRay.direction = particleOrigin.forward;

        // If the raycast hits something on the 'Shootable' layer
        if (Physics.Raycast(shootRay, out hitResult, lineRange, shootableMask))
        {
            // Set the end position of line to be the point where the raycast hit
            lineRenderer.SetPosition(1, hitResult.point);

            // Instantiate the bullet impact effect at the point of impact
            Instantiate(impactEffect, hitResult.point, Quaternion.identity);
        }

        else    // If raycast doesn't hit anything on the 'Shootable' layer
        {
            // Draw a 100-unit line (lineRange) in the forward direction
            lineRenderer.SetPosition(1, shootRay.origin + shootRay.direction * lineRange);
        }
    }


    void PlaceMine()
    {
        // Tell the inventory that a mine was placed
        gameObject.GetComponent<Inventory>().useMine();

        // Play the landmine deploy sound
        audioSource.Play();

        // Place the mine at the referenced location
        Instantiate(playerMine, mineOrigin.position, mineOrigin.rotation);
    }


    public void PlayerHasMinesTrue()
    {
        playerHasMines = true;
    }

    public void PlayerHasMinesFalse()
    {
        playerHasMines = false;
    }


    void DisableEffects()
    {
        // Turn off the light
        particleOrigin.GetComponent<Light>().enabled = false;

        // Turn off the line renderer
        lineRenderer.enabled = false;

        // Tell the laser sight that player is not firing
        gameObject.GetComponent<LaserSight>().playerIsShooting = false;
    }
}
