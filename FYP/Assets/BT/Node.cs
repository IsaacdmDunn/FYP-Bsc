using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Node
{
    public NodeState nodeState;
    public NodeState GetNodeState { get { return nodeState; } }
    public abstract NodeState Evaluate();
    public enum NodeState
    {
        running, success, failure
    }
}
