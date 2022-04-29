using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Node
{
    protected List<Node> nodes = new List<Node>();
    public Inverter(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    public override NodeState Evaluate()
    {
        foreach (var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.running:
                    nodeState = NodeState.running;
                    break;
                case NodeState.success:
                    nodeState = NodeState.failure;
                    break;
                case NodeState.failure:
                    nodeState = NodeState.success;
                    return nodeState;
                    break;
                default:
                    break;
            }
        }
        return nodeState;
    }

}
