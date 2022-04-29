using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkNode : Node
{
    bool isInConversation;
    CastManager target;
    CharacterInfo origin;
    int id;
    int timer = 60;

    public TalkNode(bool isInConversation, CharacterInfo origin, CastManager target)
    {
        this.isInConversation = isInConversation;
        this.target = target;
        this.origin = origin;
        id = Random.Range(0,target.cast.Count-1);
    }

    public override NodeState Evaluate()
    {
        timer--;
        if (timer == 0)
        {
            timer = 600;
            origin.gameObject.GetComponent<Jobs>().type = Jobs.taskType.speak;
            origin.dialogGen.PickRandomPerson();
            origin.dialogGen.CreateDialog();
        }
        //return NodeState.running;
        
        return NodeState.success;
    }

    
}
