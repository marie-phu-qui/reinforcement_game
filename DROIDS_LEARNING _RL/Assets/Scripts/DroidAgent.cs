using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using MLAgents;

public class DroidAgent : Agent
{

    Rigidbody m_AgentRb;

    public GameObject UIObject;
    public int mods = 0;

    public bool useVectorObs;

    public override void InitializeAgent()
    {
        base.InitializeAgent();
        m_AgentRb = GetComponent<Rigidbody>();
    }

    public override void CollectObservations()
    {
        if (useVectorObs)
        {
            AddVectorObs(transform.InverseTransformDirection(m_AgentRb.velocity));
        }
    }

    public void MoveAgent(float[] act)
    {
        var rotateDir = Vector3.zero;

        var action = Mathf.FloorToInt(act[0]);
        switch (action)
        {
            case 3:
                rotateDir = transform.up * 1f;
                break;
            case 4:
                rotateDir = transform.up * -1f;
                break;
        }
        transform.Rotate(rotateDir, Time.deltaTime * 200f);
        m_AgentRb.AddForce(transform.forward * 3f, ForceMode.VelocityChange); //moves forward continually
    }

    public override void AgentAction(float[] vectorAction)
    {
        AddReward(-1f / agentParameters.maxStep);
        MoveAgent(vectorAction);
        if (transform.position.y < 0)
        {
            Done();
        }
        if (transform.rotation.y != 0)
        {
            AddReward(-1f / agentParameters.maxStep);
        }

    }

    public override float[] Heuristic()
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
        return new float[] { 0 };
    }

    public override void AgentReset()
    {
        transform.position = new Vector3(0, 0.5f, -26.61f);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        mods = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
        Debug.Log("Ouille");
        SetReward(-0.000001f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("block"))
        {
            Debug.Log("Aie");
            SetReward(-1f);
        }
        if (other.gameObject.CompareTag("trigger"))
        {
            Debug.Log("mods");
            SetReward(+1f);
        }
    }

    public override void AgentOnDone()
    {
    }
}

