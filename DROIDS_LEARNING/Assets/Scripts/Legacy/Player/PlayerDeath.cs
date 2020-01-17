﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDeath : MonoBehaviour
{
		
		// PUBLIC VARIABLES
		public bool playerIsDead = false;
		public float restartDelay = 5f;

		public GameObject droid;
        public GameObject droidLight;
        public Transform spawnPoint01;

		[Header("EFFECTS")]
		public GameObject smokeEffect;                                        // Reference to the smoke effect
		public GameObject explosionEffect;                                    // Reference to the explosion effect
       
       
        // PRIVATE VARIABLES
		float deathTimer;
		MeshRenderer droidMeshRender;
        MeshRenderer lightMeshRender;
        BoxCollider boxCollider;
		PlayerControl playerControlScript;
        PlayerFire playerFireScript;


		private void Awake()
		{
			droidMeshRender = droid.GetComponent<MeshRenderer>();               // Set up the reference to the Mesh Renderer
            lightMeshRender = droidLight.GetComponent<MeshRenderer>();          // Set up the reference to the wee red light
            boxCollider = GetComponent<BoxCollider>();                          // Set up the reference to the Box Collider
			playerControlScript = GetComponent<PlayerControl>();                // Set up the reference to the PlayerControl script
            playerFireScript = GetComponent<PlayerFire>();                      // Set up the reference to the FireProjectile script
		}

        
		private void Update()
		{
			// If the player is dead ..
			if (playerIsDead == true)
			{
				// .. start counting up to the restartDelay time
				deathTimer += Time.deltaTime;

                // If the death timer has reached the delay time ..
				if (deathTimer >= restartDelay)
				{
					// This enacts the respawn
					gameObject.transform.position = spawnPoint01.transform.position;

					// This zeroes player momentum
					gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

					// This sets the health back to its initial state
					gameObject.GetComponent<PlayerHealth>().resetHealth();

					// This stops the smoke effect
					smokeEffect.GetComponent<ParticleSystem>().Stop();

					// Let the void Update() know that the player is alive again (stop the timer)
					playerIsDead = false;

					// Reset the death timer.
					deathTimer = 0;

					// Turn the mesh renderers back on
					droidMeshRender.enabled = true;
                    lightMeshRender.enabled = true;

					// Turn the box collider back on
					boxCollider.enabled = true;

					// Turn on the movement and shooting scripts.
					playerControlScript.enabled = true;
					playerFireScript.enabled = true;
				}
			}
		}

		void HandleDeath()
		{
			// Let the void Update() know that the player has died
			playerIsDead = true;

            // Makes the player invisible
            droidMeshRender.enabled = false;
            lightMeshRender.enabled = false;

            // Disables collisions
            boxCollider.enabled = false;

            // Instantiate the explosion effect
			Instantiate(explosionEffect, transform.position, transform.rotation);

			// This removes one life from the player upon death
			// gameObject.GetComponent<PlayerControl>().UpdateLives(-1);
		}
}