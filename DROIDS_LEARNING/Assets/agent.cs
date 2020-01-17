using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class agent : Agent
{
    // Start is called before the first frame update
    Rigidbody rBody;
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        print(rBody);
    }
    public Transform Target;
    public override void AgentReset()
    {
        // If the player has collision with the right side walk 
        // go left
        print(this.transform.position.x);
        if (this.transform.position.x < -6)
        {
            print("choc à gauche");
        }
        // If the player has collision with the left side walk 
        // go right
        else if (this.transform.position.x > 6)
        {
            print("choc à droite");
        }
    }
}
