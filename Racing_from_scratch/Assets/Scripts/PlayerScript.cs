using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody player;
    Rigidbody Target;

    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    public void PlayerReset()
    {
        //whenever done()
        this.player.angularVelocity = Vector3.zero;
        this.player.velocity = Vector3.zero;
        this.transform.position = new Vector3(0, 0.5f, -4);
    }

    public void MovePlayer(float[] act)
    {
        var dirToGo = Vector3.zero;
        var rotateDir = Vector3.zero;

        var action = Mathf.FloorToInt(act[0]);
        switch (action)
        {
            case 1:
                dirToGo = transform.forward * 1f;
                break;
            case 2:
                dirToGo = transform.forward * -1f;
                break;
            case 3:
                rotateDir = transform.up * 1f;
                break;
            case 4:
                rotateDir = transform.up * -1f;
                break;
        }
        transform.Rotate(rotateDir, Time.deltaTime * 200f);
        player.AddForce(dirToGo * 2f, ForceMode.VelocityChange);
    }

    public void PlayerAction(float[] vectorAction)
    {
        MovePlayer(vectorAction);

        if (transform.position.y < 0)
        {
            PlayerReset();
        }

        if ((transform.position.z < -6) || (transform.position.z > 56))
        {
            PlayerReset();
        }

        if ((transform.position.x < -5) || (transform.position.x > 5))
        {
            PlayerReset();
        }
    }

    public float[] Heuristic()
    {
        if (Input.GetKey("right"))
        {
            return new float[] { 3 };
        }
        if (Input.GetKey("up"))
        {
            return new float[] { 1 };
        }
        if (Input.GetKey("left"))
        {
            return new float[] { 4 };
        }
        if (Input.GetKey("down"))
        {
            return new float[] { 2 };
        }
        return new float[] { 0 };
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("goal"))
        {
            PlayerReset();
        }
    }
}
