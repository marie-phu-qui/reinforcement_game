using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveCam : MonoBehaviour
{
    [Header("CAMERA SETTINGS")]
    public float YDistance = 20;
    public float ZDistance = -24;
    public float dampening = 5f;

    [Header("PUBLIC REFERENCES")]
    public Transform playerPosition;
    // public Transform spawnPoint01;

    [Header("DEBUG")]
    public bool gameIsActive = false;
    public float delayBeforeGameBegins;

    // PRIVATE VARIABLES
    Vector3 cameraOffset;
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        // Calculate the initial offset
        // initialOffset = playerPosition.position + new Vector3(0,10,-16.6f);

        cameraOffset = new Vector3(0, YDistance, ZDistance);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;            // counts up

        if (timer >= delayBeforeGameBegins)
        {
            gameIsActive = true;
        }
    }
    
    // This is called once per physics frame
    void FixedUpdate()
    {
        if (gameIsActive == true)
        {
            // Create a position for the camera to aim at, based on the offset from the target.
            Vector3 targetCamPos = playerPosition.position + cameraOffset;

            // Smoothly interpolate between the camera's current position and it's target position.
            transform.position = Vector3.Lerp(transform.position, targetCamPos, dampening * Time.deltaTime);
        }
    }

    public void beginGame()
    {
        gameIsActive = true;
    }

    public void SetDelayBeforeGameBegins(float delay)
    {
        delayBeforeGameBegins = delay;
    }
}
