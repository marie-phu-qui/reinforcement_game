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

    /*public override void AgentReset()
    {
        if (this.transform.position.x > 7f)
        {
            // If the Agent collides on right wall : zero its position
            this.transform.position = new Vector3(0, 0, -26.61f);
        }
        if (this.transform.position.x < -7f)
        {
            // If the Agent collides on left wall : zero its position
            this.transform.position = new Vector3(0, 0, -26.61f);
        }

   
        // Move the target stack of boxes to a new spot
        Target.position = new Vector3(Random.Range(-7f, 7f), 0, this.transform.position.z + 10);      
    
    }*/

    public override void CollectObservations()  
    {
        // Agent positions
        AddVectorObs(this.transform.position);

        // Array of the tracks
    }


    public Transform Stack1;
    public Transform Stack2;
    public Transform Stack3;
    public override void AgentAction(float[] vectorAction)
    {

        // The most Mods reached = Reward - TO DO


        // Penalties if touched a stack
        float distanceToStack1 = Vector3.Distance(this.transform.position, Stack1.position);
        float distanceToStack2 = Vector3.Distance(this.transform.position, Stack2.position);
        float distanceToStack3 = Vector3.Distance(this.transform.position, Stack3.position);
        // Touched target
        if (distanceToStack1 < 1.42f)
        {
            SetReward(-1.0f);
        }
        if (distanceToStack2 < 1.42f)
        {
            SetReward(-1.0f);
        }
        if (distanceToStack3 < 1.42f)
        {
            SetReward(-1.0f);
        }


        // Rewards - Penalties if toush the curb
        // Touched right side
        if (this.transform.position.x > 6f)
        {
            SetReward(-1.0f);
        }

        // Touched left side
        if (this.transform.position.x < -6f)
        {
            SetReward(-1.0f);
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


