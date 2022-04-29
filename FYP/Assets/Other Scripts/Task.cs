using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public Task(Vector3 _pos, taskType _type, CharacterInfo _character)
    {
        pos = _pos;
        type = _type;
        character = _character;
    }

    public Vector3 pos;
    public CharacterInfo character;
    public bool taskComplete;
    public taskType type;
    public enum taskType { idle, walkTo, farm, mine, speak, attack, kill, befreind, flirt};
}
