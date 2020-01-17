using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSight : MonoBehaviour
{
    [Header("LASER SETTINGS")]
    public float lineRange = 100f;                      // Length of line drawn

    [Header("PUBLIC REFERENCES")]
    public Transform laserOrigin;

    [Header("DEBUG")]
    public bool playerIsShooting = false;

    // PRIVATE VARIABLES
    LineRenderer lineRenderer;
    Ray shootRay = new Ray();                           // Raycast from ParticleOrigin forwards (Z axis)
    RaycastHit hitResult;                               // The object hit by the raycast?
    int shootableMask;                                  // Layer No. of 'Shootable' mask


    // Start is called before the first frame update
    void Start()
    {
        // Give 'lineRenderer' a value
        lineRenderer = laserOrigin.GetComponent<LineRenderer>();

        // Give 'shootableMask' a value - returns the number of the 'Shootable' layer
        shootableMask = LayerMask.GetMask("Shootable");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && playerIsShooting == false)
        {
            // Turn on the line renderer
            lineRenderer.enabled = true;

            // Set the point at which to begin drawing the line
            lineRenderer.SetPosition(0, laserOrigin.position);

            // Set the point at which to begin the raycast
            shootRay.origin = laserOrigin.position;

            // Set the direction for the raycast
            shootRay.direction = laserOrigin.forward;

            // If the raycast hits something on the 'Shootable' layer
            if (Physics.Raycast(shootRay, out hitResult, lineRange, shootableMask))
            {
                // Set the end position of line to be the point where the raycast hit
                lineRenderer.SetPosition(1, hitResult.point);
            }

            else    // If raycast doesn't hit anything on the 'Shootable' layer
            {
                // Draw a 100-unit line (lineRange) in the forward direction
                lineRenderer.SetPosition(1, shootRay.origin + shootRay.direction * lineRange);
            }
        }

        else
        {
            // Turn on the line renderer
            lineRenderer.enabled = false;
        }
    }
}
