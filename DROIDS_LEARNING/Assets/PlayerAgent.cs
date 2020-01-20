using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class PlayerAgent : Agent
{
    Rigidbody rBody;
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    public override void AgentReset()
    {
        if (this.transform.position.x > -7f)
        {
            // If the Agent collides on right wall : zero its position
            this.transform.position = new Vector3(0, 0, 0);
        }
        if (this.transform.position.x < -6f)
        {
            // If the Agent collides on left wall : zero its position
            this.transform.position = new Vector3(0, 0, 0);
        }

    }

    public override void CollectObservations()  
    {
        // Agent positions
        AddVectorObs(this.transform.position);

        // Array of the tracks
    }
    public override void AgentAction(float[] vectorAction)
    {
        // Rewards - Penalties if toush the curb


        // Touched right side
        if (this.transform.position.x > 6f)
        {
            SetReward(-1.0f);
            Done();
        }

        // Touched left side
        if (this.transform.position.x < -6f)
        {
            SetReward(-1.0f);
            Done();
        }

    }
    public override float[] Heuristic()
    {
        var action = new float[2];
        action[0] = Input.GetAxis("Horizontal");
        action[1] = Input.GetAxis("Vertical");
        return action;
    }
}


