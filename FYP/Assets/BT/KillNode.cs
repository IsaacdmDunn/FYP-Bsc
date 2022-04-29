using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillNode : Node
{
    List<int> causedBy = new List<int>();
    List<int> affected = new List<int>();
    CharacterInfo origin; CharacterInfo target; CastManager cast; bool isMurder;
    public KillNode(CharacterInfo origin, CharacterInfo target, CastManager cast, bool isMurder)
    {
        this.cast = cast;
        this.origin = origin;
        this.isMurder = isMurder;
        this.target = target;
    }

    public override NodeState Evaluate()
    {
        origin.angry = 0f;
        if (Random.Range( 0,3) == 0)
        {
            if (isMurder)
            {

                causedBy.Add(origin.id);
                affected.Add(target.id);
                Memory memToAdd = new Memory(null, 0, 0, null, null, null);
                memToAdd.affectedChar = affected;
                memToAdd.causedByChar = causedBy;
                memToAdd.cast = cast.cast;
                memToAdd.timeStamp = 0;
                memToAdd.id = 1;
                memToAdd.precon = null;
                for (int j = 0; j < cast.cast.Count; j++)
                {
                    if (j != affected[0] && j != causedBy[0] && cast.cast[j].isAlive)
                    {
                        cast.cast[j].brain.Add(memToAdd);

                    }

                }
                //}
                target.isAlive = false;
            }
            return NodeState.success;
        }
        else
        {
            if (isMurder)
            {
                //add memory for tried to kill
            }
            return NodeState.failure;
        }
        

        
    }
}
