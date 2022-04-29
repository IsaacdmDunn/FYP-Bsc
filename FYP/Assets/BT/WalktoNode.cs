using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalktoNode : Node
{
    public Vector3 target;
    public Transform origin;
    public bool isIdle;
    public float offset = 0.1f;

    public WalktoNode(Vector3 target, Transform origin, bool isIdle)
    {
        this.origin = origin;
        this.target = target;
        this.target += new Vector3(0.5f,0,0);
        this.isIdle = isIdle;
    }

    public override NodeState Evaluate()
    {
        origin.gameObject.GetComponent<Jobs>().type = Jobs.taskType.walkTo;
        if (isIdle)
        {
            origin.gameObject.GetComponent<Jobs>().type = Jobs.taskType.idle;
        }
        float step = 2f * Time.deltaTime; // calculate distance to move
        
        if (Vector3.Distance(origin.transform.position, target) < 0.1f)
        {
            if (isIdle)
            {
                target = new Vector3(Random.Range(-4, 5), Random.Range(-3, 3), 0);
            }
            return NodeState.success;
        }
        else
        {
            origin.transform.position = Vector3.MoveTowards(origin.transform.position, target, step);
        }
        //return NodeState.running;
        return NodeState.success;
    }
}
