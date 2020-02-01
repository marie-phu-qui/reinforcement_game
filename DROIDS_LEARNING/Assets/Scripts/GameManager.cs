using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("GAME SETTINGS")]
    public float delayBeforeGameBegins = 5.0f;


    [Header("REFERENCES")]
    public GameObject perspectiveCam;


    // Start is called before the first frame update
    void Start()
    {
        perspectiveCam.GetComponent<PerspectiveCam>().SetDelayBeforeGameBegins(delayBeforeGameBegins);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
