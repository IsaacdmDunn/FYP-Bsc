using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{
    public int id;
    public int timeStamp;
    public List<int> causedByChar;
    public List<int> affectedChar;
    public List<CharacterInfo> cast;
    public Action precon;
    bool preconditionMet = false;
    GameEvents e;
    //precondition system idk what to put here
    public Memory(GameEvents _e, int _id, int _timeStamp, List<int> _causedByChar, List<int> _affectedChar, List<CharacterInfo> _cast)
    {
        id = _id;
        timeStamp = _timeStamp;
        causedByChar = _causedByChar;
        affectedChar = _affectedChar;
        cast = _cast;
        //precon = Precondition;
        e = _e;
    }

    

  
}